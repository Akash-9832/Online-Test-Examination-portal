/*using Microsoft.AspNetCore.Mvc;

namespace OnlineTest.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
*/


/*
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace OnlineTest.Controllers
{
    public class AccountController : Controller
    {
        public object Session { get; private set; }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                using (DB_Entities db = new DB_Entities())
                {
                    var obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("UserDashboard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
*/


using System;
using System.IO;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

public class AccountController : Controller
{

    // POST: Login/ValidateLogin
    [HttpPost]
    public ActionResult ValidateLogin(string userId, string dob)
    {
        // Validation logic using the Excel file
        string result = ValidateLoginWithExcel(userId, dob);

        // Return the result (e.g., "userid, You are successfully login" or "Login failed")
        return Content(result);
    }

    // Method to validate login using Excel file
    private string ValidateLoginWithExcel(string userId, string dob)
    {
        // Path to your Excel file containing user data
        string excelFilePath = Server.MapPath("C:\\Users\\Akash\\Downloads\\ExamResult.xlsx");

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
                    string excelUserId = worksheet.Cells[row, 1].Value?.ToString(); // Assuming user ID is in column A
                    string excelDob = worksheet.Cells[row, 2].Value?.ToString(); // Assuming DOB is in column B

                    // Check if user ID and DOB match
                    if (userId == excelUserId && dob == excelDob)
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
}
