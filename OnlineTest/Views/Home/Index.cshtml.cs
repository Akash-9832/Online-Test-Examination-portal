/*using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace OnlineTest.Views.Home
{
    public class Index
    {
    }
}
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml;
using System;
using System.IO;

namespace OnlineTest.Views.Home
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public IActionResult OnPost(string userid, string dob)
        {
            // Path to your Excel file
            string excelFilePath = "C:\\Users\\Akash\\Downloads\\ExamResult.xlsx";

            try
            {
                // Open the Excel file
                FileInfo fileInfo = new FileInfo(excelFilePath);
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first worksheet

                    // Iterate through rows to find matching user credentials
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Assuming header is in row 1
                    {
                        string excelUserId = worksheet.Cells[row, 3].Value?.ToString(); // Assuming user ID is in column A
                        string excelDob = worksheet.Cells[row, 2].Value?.ToString(); // Assuming DOB is in column B

                        // Check if user ID and DOB match
                        if (userid == excelUserId && dob == excelDob)
                        {
                            // Successful login
                            Message = $"{userid}, You are successfully logged in";
                            return Page();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Message = $"Error: {ex.Message}";
                return Page();
            }

            // If no matching user found or any error occurred
            Message = "Login failed";
            return Page();
        }
    }
}
