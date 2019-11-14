using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeLouisvilleWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CodeLouisvilleWeb.Pages
{
    public class IndexModel : PageModel
    {
        private StudentRepository _studentRepository;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(StudentRepository studentRepository, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        [BindProperty]
        public int? StudentId { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string ClassName { get; set; }

        [BindProperty]
        public DateTimeOffset? StartDate { get; set; }

        [BindProperty]
        public string LastClassCompleted { get; set; }

        [BindProperty]
        public DateTimeOffset? LastClassCompletedOn { get; set; }
        
        public ActionResult OnGet(int? studentId, string message)
        {
            ViewData["Message"] = message;

            if(studentId.HasValue)
            {
                var student = _studentRepository.Get(studentId.Value);
            }

            return Page();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
                return Page();

            try
            {
                _studentRepository.Add(new Student
                {
                    ClassName = ClassName,
                    FirstName = FirstName,
                    LastClassCompleted = LastClassCompleted,
                    LastName = LastName,
                    StudentId = StudentId,
                    StartDate = StartDate,
                    LastClassCompletedOn = LastClassCompletedOn
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Page();
            }

            return RedirectToPage("Index", new { message = $"Student {FirstName} with ID {StudentId} was saved" });
        }
    }
}
