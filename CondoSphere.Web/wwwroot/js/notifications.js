"use strict";

// This check ensures the script only runs if the user is logged in (jwtToken is defined on the page)
if (typeof jwtToken !== 'undefined' && jwtToken && typeof apiBaseUrl !== 'undefined' && apiBaseUrl) {

    // 1. Establish the connection to the SignalR hub
    const connection = new signalR.HubConnectionBuilder()
        .withUrl(`${apiBaseUrl}/notificationHub`, {
            // Pass the JWT token for authentication
            accessTokenFactory: () => jwtToken
        })
        .configureLogging(signalR.LogLevel.Information)
        .build();

    // 2. Define the client-side method that the server will call ("ReceiveNotification")
    connection.on("ReceiveNotification", function (notification) {
        console.log("Notification received: ", notification);

        // Find the notification UI elements
        const badge = document.getElementById('notification-badge');
        const notificationList = document.getElementById('notification-list');
        const bellIconLink = document.getElementById('notificationDropdown');

        // Update the unread count badge
        if (badge) {
            let currentCount = parseInt(badge.innerText) || 0;
            badge.innerText = currentCount + 1;
            badge.style.display = 'inline-block'; // Make sure it's visible
        } else {
            // If the badge doesn't exist, create it (for the first unread notification)
            if (bellIconLink) {
                // Using innerHTML is simpler here to add the complex span structure
                bellIconLink.innerHTML += `
                    <span class="position-absolute top-1 start-80 translate-middle badge rounded-pill bg-danger" id="notification-badge">
                        1<span class="visually-hidden">unread notifications</span>
                    </span>`;
            }
        }

        // Create the new notification HTML list item
        if (notificationList) {
            const newNotificationLi = document.createElement('li');
            newNotificationLi.innerHTML = `
                <a class="dropdown-item text-wrap fw-bold" href="${notification.linkUrl}">
                    <div class="small text-muted">${new Date(notification.sentDate).toLocaleString()}</div>
                    ${notification.title}
                </a>`;

            // Add the new notification to the top of the list
            notificationList.prepend(newNotificationLi);

            // Remove the "No new notifications" message if it exists
            const noNotificationsItem = notificationList.querySelector('.no-notifications-item');
            if (noNotificationsItem) {
                noNotificationsItem.remove();
            }
        }

        // You can add a more sophisticated toast notification here if you wish
        // For example, using a library like Toastr.js or Bootstrap's built-in Toasts.
        // alert(`New Notification: ${notification.title}`);
    });

    // 3. Logic for "Mark as Read" functionality
    const notificationDropdown = document.getElementById('notificationDropdown');
    if (notificationDropdown) {
        // Listen for the Bootstrap event that fires just before the dropdown is shown
        notificationDropdown.addEventListener('show.bs.dropdown', function () {
            const badge = document.getElementById('notification-badge');
            const notificationList = document.getElementById('notification-list');
            const unreadCount = badge ? parseInt(badge.innerText) || 0 : 0;

            // Only proceed if there are unread notifications
            if (unreadCount > 0) {
                // a. Immediately update the UI for a fast, responsive feel
                if (badge) {
                    // Hide the badge instead of removing it, so it can be shown again later
                    badge.style.display = 'none';
                    badge.innerText = '0'; // Reset the count
                }

                if (notificationList) {
                    const unreadItems = notificationList.querySelectorAll('.fw-bold');
                    unreadItems.forEach(item => {
                        item.classList.remove('fw-bold');
                    });
                }

                // b. Send a request to the API in the background to update the database
                fetch(`${apiBaseUrl}/api/notifications/mark-all-as-read`, {
                    method: 'POST',
                    headers: {
                        'Authorization': `Bearer ${jwtToken}`
                    }
                }).catch(err => console.error("Failed to mark notifications as read:", err));
            }
        });
    }

    // 4. Start the connection and handle automatic reconnection
    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.error("SignalR Connection Error: ", err);
            // Retry connection after a 5-second delay
            setTimeout(start, 5000);
        }
    };

    connection.onclose(async () => {
        console.log("SignalR Connection closed. Attempting to reconnect...");
        await start();
    });

    // Initial start of the connection
    start();
}