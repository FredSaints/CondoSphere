using CondoSphere.Web.Models;
using CondoSphere.Web.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CondoSphere.Web.Controllers
{    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
/// <summary>
/// Handles the Index action.
/// </summary>
public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                Features = new List<FeatureViewModel>
                {
                    new() {
                        IconClass = "bi-cash-coin",
                        Title = "Simplified Financials",
                        Description = "Automate billing, accept online payments, and generate insightful financial reports in just a few clicks."
                    },
                    new() {
                        IconClass = "bi-chat-dots-fill",
                        Title = "Seamless Communication",
                        Description = "Keep residents informed with announcements, manage conversations, and centralize all property-related communication."
                    },
                    new() {
                        IconClass = "bi-wrench-adjustable-circle-fill",
                        Title = "Intelligent Maintenance",
                        Description = "Track resident-reported issues, assign tasks to staff, and manage the entire maintenance workflow from start to finish."
                    }
                },
                Personas = new List<PersonaViewModel>
                {
                    new() {
                        ImageUrl = "/images/Home/manager.png",
                        RoleTitle = "For Property Managers",
                        Benefits = new List<string> { "Centralize Operations", "Reduce Admin Work", "Increase Resident Satisfaction" }
                    },
                    new() {
                        ImageUrl = "/images/Home/resident.png",
                        RoleTitle = "For Residents",
                        Benefits = new List<string> { "Pay Fees Online", "Report Issues Instantly", "Stay Connected" }
                    },
                    new() {
                        ImageUrl = "/images/Home/board-member.png",
                        RoleTitle = "For Board Members",
                        Benefits = new List<string> { "Access Real-Time Reports", "Improve Transparency", "Track Maintenance" }
                    }
                },
                Testimonials = new List<TestimonialViewModel>
                {
                    new() {
                        Quote = "CondoSphere has completely transformed how we manage our properties. Our resident communication has never been better, and we've cut down our administrative time by half.",
                        AuthorName = "Jane Doe",
                        AuthorTitle = "Property Manager, Urban Living Inc."
                    },
                    new() {
                        Quote = "As a resident, I love being able to pay my fees online and report maintenance issues from my phone. Its incredibly convenient and transparent.",
                        AuthorName = "John Smith",
                        AuthorTitle = "Resident, Sunset Gardens"
                    },
                    new() {
                        Quote = "The financial reporting tools are a game-changer for our board meetings. We have a clear, real-time overview of our property's financial health at all times.",
                        AuthorName = "Mary Johnson",
                        AuthorTitle = "Board Member, The Summit Condominiums"    }
                }
            };

            return View(viewModel);
        }  public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
