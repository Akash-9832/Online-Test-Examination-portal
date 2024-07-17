/*using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineTest.Views.Home
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
*/

using System;
using System.IO;
using OfficeOpenXml;

public class ExcelLoginValidator
{
    public static string ValidateLogin(string userId, string Dob)
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
                    string userid = worksheet.Cells[row, 2].Value?.ToString(); // Assuming user ID is in column A
                    string dob = worksheet.Cells[row, 3].Value?.ToString(); // Assuming DOB is in column B

                    // Check if user ID and DOB match
                    if (userId == userid && Dob == dob)
                    {
                        return $"{userId}, You are successfully logged in";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions
            Console.WriteLine($"Error: {ex.Message}");
        }

        // If no matching user found or any error occurred
        return "Login failed";
    }

    // Example usage:
    public static void Main(string[] args)
    {
        // Provide user ID and DOB for validation
        string userId = "123"; // Example user ID
        string Dob = "1990-01-01"; // Example DOB

        // Validate login
        string result = ValidateLogin(userId, Dob);
        Console.WriteLine(result);
    }
}
