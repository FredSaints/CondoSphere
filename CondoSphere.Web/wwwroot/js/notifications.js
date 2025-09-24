"use strict";

if (typeof window.jwtToken !== 'undefined' && window.jwtToken && typeof window.apiBaseUrl !== 'undefined' && window.apiBaseUrl) {

    const apiBaseUrl = window.apiBaseUrl;
    const jwtToken = window.jwtToken;

    // 1. Establish the connection to the SignalR hub
    const connection = new signalR.HubConnectionBuilder()
        .withUrl(`${apiBaseUrl}/notificationHub`, {
            accessTokenFactory: () => jwtToken
        })
        .configureLogging(signalR.LogLevel.Information)
        .build();

    // 2. Define the client-side method that the server will call ("ReceiveNotification")
    connection.on("ReceiveNotification", function (notification) {
        console.log("Real-time notification received: ", notification);
        const notificationList = document.getElementById('notification-list');
        const bellIconLink = document.getElementById('notificationDropdown');
        const badge = document.getElementById('notification-badge');

        if (badge) {
            let currentCount = parseInt(badge.innerText) || 0;
            badge.innerText = currentCount + 1;
            badge.style.display = 'inline-block';
        } else {
            if (bellIconLink) {
                bellIconLink.innerHTML += `
                    <span class="position-absolute badge rounded-pill bg-danger" id="notification-badge">
                        1<span class="visually-hidden">unread notifications</span>
                    </span>`;
            }
        }

        if (notificationList) {
            const newNotificationLi = document.createElement('li');
            newNotificationLi.setAttribute('data-notification-id', notification.id);
            newNotificationLi.innerHTML = `
                <a class="dropdown-item text-wrap fw-bold" href="${notification.linkUrl}">
                    <div class="small text-muted">${new Date(notification.sentDate).toLocaleString()}</div>
                    ${notification.title}
                </a>`;
            notificationList.prepend(newNotificationLi);

            checkNotificationListState();
        }
    });

    // 3. Logic to remove a notification from the list AND MARK AS READ when it's clicked
    const notificationList = document.getElementById('notification-list');
    if (notificationList) {
        notificationList.addEventListener('click', async function (event) {
            const link = event.target.closest('a.dropdown-item');
            if (link && !link.classList.contains('small')) {

                event.preventDefault();
                console.log("Notification clicked. Preventing default navigation.");

                const listItem = link.closest('li[data-notification-id]');
                const notificationId = listItem ? listItem.getAttribute('data-notification-id') : null;
                const destinationUrl = link.href;

                if (listItem) {
                    listItem.remove();
                }
                checkNotificationListState();

                if (notificationId) {
                    // --- THIS IS THE CORRECTED URL ---
                    const fetchUrl = `${apiBaseUrl}/api/notifications/mark-one-as-read/${notificationId}`;

                    console.log(`Sending API request to: ${fetchUrl}`);

                    try {
                        const response = await fetch(fetchUrl, {
                            method: 'POST',
                            headers: {
                                'Authorization': `Bearer ${jwtToken}`
                            }
                        });

                        console.log(`API response received with status: ${response.status}`);

                        if (!response.ok) {
                            const errorBody = await response.text();
                            console.error(`API Error: ${response.status} ${response.statusText}`, errorBody);
                        } else {
                            console.log("Successfully marked notification as read on the server.");
                        }

                    } catch (error) {
                        console.error("A network or script error occurred during fetch:", error);
                    } finally {
                        console.log(`Navigating to: ${destinationUrl}`);
                        window.location.href = destinationUrl;
                    }
                } else {
                    console.warn("No notification-id found on the list item. Navigating directly.");
                    window.location.href = destinationUrl;
                }
            }
        });
    }

    // 4. HELPER FUNCTION to manage the "No notifications" message
    function checkNotificationListState() {
        if (!notificationList) return;
        const notificationItems = notificationList.querySelectorAll('li[data-notification-id]');
        const noNotificationsItem = notificationList.querySelector('.no-notifications-item');
        const divider = notificationList.querySelector('.dropdown-divider');

        if (notificationItems.length === 0) {
            if (!noNotificationsItem) {
                const emptyLi = document.createElement('li');
                emptyLi.className = 'no-notifications-item';
                emptyLi.innerHTML = '<span class="dropdown-item text-muted text-center">No new notifications.</span>';
                notificationList.prepend(emptyLi);
            }
            if (divider) divider.style.display = 'none';
        } else {
            if (noNotificationsItem) {
                noNotificationsItem.remove();
            }
            if (divider) divider.style.display = 'block';
        }
    }

    document.addEventListener('DOMContentLoaded', checkNotificationListState);

    // 6. Start the connection and handle automatic reconnection
    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.error("SignalR Connection Error: ", err);
            setTimeout(start, 5000);
        }
    };

    connection.onclose(async () => {
        console.log("SignalR Connection closed. Attempting to reconnect...");
        await start();
    });

    start();
}