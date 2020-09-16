using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using dotnetweb;


namespace dotnetweb.Pages
{
    public class IndexModel : PageModel
    {
        public string[] Messages {
            get {
                return new string[] {
                    "Hello Livecoder's!",
                    "Would you like a Cup<T>?",
                    ".NET all the things!",
                    "Would you like to play a game?"
                };
            }
        }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
