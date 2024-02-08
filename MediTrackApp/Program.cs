using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MediTrackBAL;
using Spectre.Console;

namespace MediTrackApp
{
    internal class Program
    {

        static void Main(string[] args)
        {


            try
            {




                while (true)
                {
                    var rule1 = new Spectre.Console.Rule();
                    rule1.Style = Style.Parse("seagreen1");
                    AnsiConsole.Write(rule1);
                    Console.WriteLine();
                    AnsiConsole.Write(new FigletText("MediTrack Application").Color(Color.Yellow).Centered());
                    Console.WriteLine();
                    AnsiConsole.Write(rule1);
                    Console.WriteLine();

                    DisplayMedicineTable();

                    var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[lightcoral blink]Please select from below options[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                    .AddChoices(new[] {
                                                "1.Admin Login",
                                                "2.Patient Registration and Login",
                                                "3.Search Medicines",
                                                "4.Exit MediTrackApp",

                    }));

                    // Echo the fruit back to the terminal
                    switch (choice)
                    {
                        case "1.Admin Login":                           
                            AdminLogin();
                            break;

                        case "2.Patient Registration and Login":
                            PatientRegLog();
                            break;

                        case "3.Search Medicines":
                            Console.Clear();
                            GuestMainMenu();
                            break;

                        case "4.Exit MediTrackApp":
                            Console.Clear();
                            Environment.Exit(0);
                            break;


                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        //---------------------------------------------------------------ADMIN FUNCTIONALITIES SANCHIT

        static void DisplayAdminChoicesForMedicineOperations()
        {

            try
            {

                while (true)
                {
                    var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Please select from below options[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                        .AddChoices(new[] {
                            "1.Display Medicine Table","2.Search Medicine", "3.Add New Medicine",
                            "4.Delete Medicine", "5.Update Medicine", "6.Back to Admin Main Menu"
                        }));

                    // Echo the fruit back to the terminal
                    switch (choice)
                    {
                        case "1.Display Medicine Table":
                            Console.Clear();
                            DisplayMedicineTable();
                            break;

                        case "2.Search Medicine":
                            Console.Clear();
                            SearchMedicines();
                            break;

                        case "3.Add New Medicine":
                            Console.Clear();
                            AddNewMedicine();
                            break;

                        case "4.Delete Medicine":
                            Console.Clear();
                            DeleteMedicine();
                            break;

                        case "5.Update Medicine":
                            Console.Clear();
                            UpdateMedicine();
                            break;

                        case "6.Back to Admin Main Menu":
                            Console.Clear();
                            return;

                    }
                }





            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DisplayAdminChoicesForPatientRecordOperations()
        {
            try
            {
                while (true)
                {
                    var choice = AnsiConsole.Prompt(
                     new SelectionPrompt<string>()
                    .Title("[yellow]Please select from below options[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(new[] {
                         "1.Display Patient Details",  "2.Delete Patient", "3.Back To Admin Main Menu"
                    }));

                    // Echo the fruit back to the terminal
                    switch (choice)
                    {
                        case "1.Display Patient Details":
                            Console.Clear();
                            DisplayPatatientsDetails();
                            break;

                        case "2.Delete Patient":
                            Console.Clear();
                            DeletePatient();
                            break;

                        case "3.Back To Admin Main Menu":
                            Console.Clear();
                            return;


                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        static void DisplayMedicineCategory()
        {
            var rule = new Spectre.Console.Rule("[darkorange]Medicine Category Table[/]");
            rule.Style = Style.Parse("green");
            AnsiConsole.Write(rule);
            Console.WriteLine();

            DataTable medicinesCategoryTable = AdminBAL.GetMedicineCategory();
            var table = new Table();
            table.Border = TableBorder.DoubleEdge;
            table.Centered();
            table.AddColumn(new TableColumn("[orangered1 underline]Medicine Category ID[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Medicine Category Name[/]").Centered());


            foreach (DataRow row in medicinesCategoryTable.Rows)
            {
                table.AddRow($"{row["medicine_category_id"]}", $"{row["medicine_category_name"]}");
            }


            AnsiConsole.Write(table);

            Console.WriteLine();
            var rule1 = new Spectre.Console.Rule();
            rule1.Style = Style.Parse("green");
            AnsiConsole.Write(rule1);
            Console.WriteLine();
        }

        static void DisplayMedicineTable()
        {
            var rule = new Spectre.Console.Rule("[darkorange]Medicine Table[/]");
            rule.Style = Style.Parse("green");
            AnsiConsole.Write(rule);

            Console.WriteLine();

            DataTable medicinesTable = AdminBAL.GetMedicines();
            var table = new Table();
            table.Border = TableBorder.DoubleEdge;
            table.Centered();
            table.AddColumn(new TableColumn("[orangered1 underline]Medicine ID[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Medicine Name[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Category Name[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Brand Name[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Origin[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Genaration[/]").Centered());
            table.AddColumn(new TableColumn("[green underline]Cost[/]").Centered());
            table.AddColumn(new TableColumn("[green underline]Avl. Quantity[/]").Centered());

            foreach (DataRow row in medicinesTable.Rows)
            {
                table.AddRow($"{row["medicine_id"]}", $"{row["medicine_name"]}", $"{row["medicine_category_name"]}", $"{row["brand_name"]}", $"{row["medicine_origin"]}", $"{row["generation"]}", $"[darkolivegreen1_1]{row["cost"]}[/]",$"{row["medicine_quantity"]}");
            }
            AnsiConsole.Write(table);

            Console.WriteLine();
            var rule1 = new Spectre.Console.Rule();
            rule1.Style = Style.Parse("green");
            AnsiConsole.Write(rule1);
            Console.WriteLine();
        }


        static void DisplayPatatientsDetails()
        {
            var rule = new Spectre.Console.Rule("[darkorange]Medicine Table[/]");
            rule.Style = Style.Parse("green");
            AnsiConsole.Write(rule);

            Console.WriteLine();

            DataTable patientTable = AdminBAL.GetPatientsDetails();

            var table = new Table();
            table.Border = TableBorder.DoubleEdge;
            table.Centered();
            table.AddColumn(new TableColumn("[orangered1 underline]Patient ID[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Patient Name[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Patient Email[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Patient Phone[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Patient Age[/]").Centered());

            foreach (DataRow row in patientTable.Rows)
            {
                table.AddRow($"{row["patient_id"]}", $"{row["patient_name"]}", $"{row["patient_email"]}", $"{row["patient_phone"]}", $"{row["patient_age"]}");
            }


            AnsiConsole.Write(table);

            Console.WriteLine();
            var rule1 = new Spectre.Console.Rule();
            rule1.Style = Style.Parse("green");
            AnsiConsole.Write(rule1);
            Console.WriteLine();
        }


        static void AddNewMedicine()
        {
            // Update Medicine
            Console.WriteLine("\nAdding Medicine...");


            Console.WriteLine("Enter Medicine Name:");
            string medicineName = Console.ReadLine();

            Console.WriteLine("Enter Brand Name:");
            string brandName = Console.ReadLine();

            Console.WriteLine("Enter Medicine Origin:");
            string origin = Console.ReadLine();

            Console.WriteLine("Enter Generation:");
            string generation = Console.ReadLine();

            Console.WriteLine("Enter Medicine Cost:");
            decimal cost = decimal.Parse(Console.ReadLine());
            while (cost<0)
            {
                AnsiConsole.MarkupLine("[red underline]Medicine Cost can not be negative[/]");
                Console.Write("Enter Medicine Cost: ");
                cost = Convert.ToDecimal(Console.ReadLine());
            }


            Console.WriteLine("Enter Medicine Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            while (quantity < 0)
            {
                AnsiConsole.MarkupLine("[red underline]Medicine quantity can not be negative[/]");
                Console.Write("Enter Medicine Quantity: ");
                quantity = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter Category ID:");
            int categoryId = int.Parse(Console.ReadLine());

            

            // Add the product to the cart
            bool AddMedicineResult = AdminBAL.AddNewMedicine(medicineName, brandName, origin, generation, cost, quantity, categoryId);

            if (AddMedicineResult)
            {
                AnsiConsole.MarkupLine("[green]Medicine added successfully![/]");
                Console.WriteLine("Medicine Table ");
                DisplayMedicineTable();
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Please enter valid data for addng the medicine record[/]");
                AnsiConsole.MarkupLine("[red]Failed to add medicine. Please try again.[/]");
            }


        }


        static void DeleteMedicine()
        {
            AnsiConsole.MarkupLine("[yellow blink]Select Medicine ID from below table to delete particular medicine[/]");
            DisplayMedicineTable();

            Console.Write("Enter the Medicine ID To Delete ");
            int medicineIdToDelete = Convert.ToInt32(Console.ReadLine());


            
            while (true)
            {
                AnsiConsole.MarkupLine("[red underline]Are you sure you want to delete? Press Y/N[/]");
                string yesNoChoice = Console.ReadLine();

                // Convert input to uppercase for case-insensitive comparison
                yesNoChoice = yesNoChoice.ToUpper();

                if (yesNoChoice == "Y")
                {
                    // User confirmed deletion, perform the deletion logic here                  
                    bool deleteMedicineResult = AdminBAL.DeleteMedicine(medicineIdToDelete);

                    if (deleteMedicineResult)
                    {
                        AnsiConsole.MarkupLine("[green]Medicine Deleteted successfully![/]");
                        Console.WriteLine("Updated Medicine Table");
                        DisplayMedicineTable();
                    }
                    else
                    {
                        Console.WriteLine();    
                        AnsiConsole.MarkupLine($"[red]Medicine ID {medicineIdToDelete} cannot be found in record.Please enter valid Medicine ID[/]");
                        AnsiConsole.MarkupLine("[red]Please try again.[/]");
                    }
                    break;
                }
                else if (yesNoChoice == "N")
                {
                    // User chose not to delete, handle accordingly
                    Console.WriteLine("Deletion canceled.");
                    break;
                }
                else
                {
                    // Invalid input, handle appropriately (e.g., show an error message)
                    Console.WriteLine("Invalid choice. Please enter Y or N.");
                    continue;
                }

            }




     

        }


        static void DeletePatient()
        {

            AnsiConsole.MarkupLine("[yellow blink]Enter Patient ID from below table to delete the patient record[/]");
            DisplayPatatientsDetails();

            Console.Write("Enter the Patient ID to delete patient detail: ");
            int patientIdToDelete = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                AnsiConsole.MarkupLine("[red underline]Are you sure you want to delete? Press Y/N[/]");
                string yesNoChoice = Console.ReadLine();

                // Convert input to uppercase for case-insensitive comparison
                yesNoChoice = yesNoChoice.ToUpper();

                if (yesNoChoice == "Y")
                {
                    // User confirmed deletion, perform the deletion logic here
                    bool deletePatientResult = AdminBAL.DeletePatient(patientIdToDelete);

                    if (deletePatientResult)
                    {
                        AnsiConsole.MarkupLine("[green blink]Patient Detail Deleteted successfully![/]");
                        AnsiConsole.MarkupLine("[yellow blink]Updated Patient Table[/]");
                        DisplayPatatientsDetails();
                    }
                    else
                    {
                        Console.WriteLine();
                        AnsiConsole.MarkupLine($"[red]Patient ID {patientIdToDelete} cannot be found in the record, Please enter valid Pateint ID[/]");
                        AnsiConsole.MarkupLine("[red]Please try again.[/]");
                    }
                    break;
                }
                else if (yesNoChoice == "N")
                {
                    // User chose not to delete, handle accordingly
                    Console.WriteLine("Deletion canceled.");
                    break;
                }
                else
                {
                    // Invalid input, handle appropriately (e.g., show an error message)
                    Console.WriteLine("Invalid choice. Please enter Y or N.");
                    continue;
                }

            }



        }


        static void UpdateMedicine()
        {
            AnsiConsole.MarkupLine("[yellow blink]Select Medicine ID from below table to update particular medicine[/]");
            DisplayMedicineTable();

            AnsiConsole.MarkupLine("[red blink]Enter Medicine Category ID from below table to update the medicine with particular category[/]");
            Console.WriteLine();
            DisplayMedicineCategory();
            // Update Medicine
            AnsiConsole.MarkupLine("\n[cyan blink]Updating Medicine...[/]");

            // Get input from the user
            Console.Write("Enter the MedicineId you want to update: ");
            int medicineIdToUpdate = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter updated MedicineName (press Enter to skip): ");
            string updatedMedicineName = Console.ReadLine();

            Console.Write("Enter updated BrandName (press Enter to skip): ");
            string updatedBrandName = Console.ReadLine();

            Console.Write("Enter updated Origin (press Enter to skip): ");
            string updatedOrigin = Console.ReadLine();

            Console.Write("Enter updated Generation (press Enter to skip): ");
            string updatedGeneration = Console.ReadLine();

            Console.Write("Enter updated Cost (press Enter to skip): ");
            decimal? updatedCost = null;
            if (decimal.TryParse(Console.ReadLine(), out decimal cost))
            {
                updatedCost = cost;
            }

            Console.Write("Enter updated CategoryId category name is given in above table that maps with Category ID (press Enter to skip): ");
            int? updatedCategoryId = null;
            if (int.TryParse(Console.ReadLine(), out int categoryId))
            {
                updatedCategoryId = categoryId;
            }


            Console.Write("Enter Quantity of Medicine: ");
            int? medUpdatedQuantity = null;
            if (int.TryParse(Console.ReadLine(), out int medQuantity))
            {
                medUpdatedQuantity = medQuantity;
            }



            bool UpdateMedicineResult = AdminBAL.UpdateMedicine(
              medicineIdToUpdate,
              string.IsNullOrEmpty(updatedMedicineName) ? null : updatedMedicineName,
              string.IsNullOrEmpty(updatedBrandName) ? null : updatedBrandName,
              string.IsNullOrEmpty(updatedOrigin) ? null : updatedOrigin,
              string.IsNullOrEmpty(updatedGeneration) ? null : updatedGeneration,
              updatedCost,
              updatedCategoryId,
              medUpdatedQuantity
            );


            if (UpdateMedicineResult)
            {
                Console.WriteLine("Medicine Updated successfully..");
                Console.WriteLine("\nMedicine Table After Update:");
                DisplayMedicineTable();

            }
            else
            {
                Console.WriteLine();    
                AnsiConsole.MarkupLine("[red]Please enter valid data for updataing the medicine record[/]");
                AnsiConsole.MarkupLine("[red]Check for valid medicine id.[/]");
                AnsiConsole.MarkupLine("[red]Note: cost, category id and medicine quantiities must be in positve numbers[/]");
                AnsiConsole.MarkupLine("[red]Failed to Update the Medicine. Please try again.[/]");
            }
        }


        //--------------------------------------------------------------SEARCH MEDICINE SAMEEP

        static void SearchMedicines()
        {

            while (true)
            {
                Console.WriteLine("╔═════════════════════════════════════════╗");
                Console.WriteLine("║    ---------- Search Bar ----------     ║");
                Console.WriteLine("╚═════════════════════════════════════════╝");
                string searchTerm;

                var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[lightcoral blink]Search By: [/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(new[] {
                        "1. Medicine Name",
                        "2. Brand Name",
                        "3. Generation",
                        "4. Medicine Category",
                        "5. Medicine Origin",
                        "6. Any Term",
                        "Go Back"

                }));

                // Echo the fruit back to the terminal
                switch (choice)
                {
                    case "1. Medicine Name":
                        Console.Clear();
                        DisplayMedicineTable();
                        Console.WriteLine("Enter Medicine Name");
                        break;

                    case "2. Brand Name":
                        Console.Clear();
                        DisplayMedicineTable();
                        Console.WriteLine("Enter Brand Name");
                        break;

                    case "3. Generation":
                        Console.Clear();
                        DisplayMedicineTable();
                        Console.WriteLine("Enter Generation");
                        break;

                    case "4. Medicine Category":
                        Console.Clear();
                        DisplayMedicineTable();
                        Console.WriteLine("Enter Medicine Category");
                        break;

                    case "5. Medicine Origin":
                        Console.Clear();
                        DisplayMedicineTable();
                        Console.WriteLine("Enter Medicine Origin");
                        break;

                    case "6. Any Term":
                        Console.Clear();
                        DisplayMedicineTable();
                        Console.WriteLine("Enter Any Term");
                        break;

                    case "Go Back":
                        Console.Clear();
                        return;
                }
                searchTerm = Console.ReadLine();
                DisplaySearchResult(choice, searchTerm);

            }

        }

        static void DisplaySearchResult(string choice, string searchTerm)
        {
            try
            {

                var rule = new Spectre.Console.Rule("[darkorange]Medicine Table Search Result[/]");
                rule.Style = Style.Parse("green");
                AnsiConsole.Write(rule);
                Console.WriteLine();
                // Retrieve search results using BAL
                DataTable searchResults = SearchingBAL.SearchMedicine(choice, searchTerm);
                AnsiConsole.MarkupLine($"[cyan blink]Search Results for '{searchTerm}':[/]");
                var table = new Table();
                table.Border = TableBorder.DoubleEdge;
                table.Centered();
                table.AddColumn(new TableColumn("[orangered1 underline]Medicine ID[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Medicine Name[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Category Name[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Brand Name[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Origin[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Genaration[/]").Centered());
                table.AddColumn(new TableColumn("[green underline]Cost[/]").Centered());
                table.AddColumn(new TableColumn("[green underline]Avl. Quantity[/]").Centered());

                // Display the search results
                foreach (DataRow row in searchResults.Rows)
                {
                    table.AddRow($"{row["medicine_id"]}", $"{row["medicine_name"]}", $"{row["medicine_category_name"]}", $"{row["brand_name"]}", $"{row["medicine_origin"]}", $"{row["generation"]}", $"[darkolivegreen1_1]{row["cost"]}[/]", $"{row["medicine_quantity"]}");
                }
                AnsiConsole.Write(table);

                Console.WriteLine();
                var rule1 = new Spectre.Console.Rule();
                rule1.Style = Style.Parse("green");
                AnsiConsole.Write(rule1);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Error in DisplaySearchResults: {ex.Message}");
                Console.ResetColor();
            }
        }


        //--------------------------------------------------------------PATIENT REGISTRAION AND LOG IN

        static void PatientRegLog()
        {
       
            while (true)
            {

                var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[lightcoral blink]Please select from below options[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(new[] {
                                        "1.Patient Register",
                                        "2.Patient Login",
                                        "3.Forgot Password",
                                        "4.Go Back",
                }));

                switch (choice)
                {
                    case "1.Patient Register":
                        Console.WriteLine("\n~~~~~~~~~~~~~~~ Registration ~~~~~~~~~~~~~~~");

                        Console.Write("Enter patient name for registration: ");
                        string patientName = Console.ReadLine();

                        while (string.IsNullOrWhiteSpace(patientName) || ContainsNumbers(patientName))
                        {
                            if (string.IsNullOrWhiteSpace(patientName))
                            {
                                AnsiConsole.MarkupLine("[red underline]Name cannot be empty. Please enter a valid name.[/]");
                            }
                            else
                            {
                                AnsiConsole.MarkupLine("[red underline]Name cannot contain numbers. Please enter a valid name.[/]");
                            }
                            
                            Console.Write("Enter patient name for registration: ");
                            patientName = Console.ReadLine();
                        }

                        Console.Write("Enter patient email for registration: ");
                        string patientEmail = Console.ReadLine();

                        while (!IsValidEmail(patientEmail))
                        {
                          
                            AnsiConsole.MarkupLine("[red underline]Invalid email format. Please enter a valid email address.[/]");
                         
                            Console.Write("Enter patient email for registration: ");
                            patientEmail = Console.ReadLine();
                        }

                        double patientPhone;

                        while (true)
                        {
                            Console.Write("Enter patient Phone for registration: ");
                            string input = Console.ReadLine();

                            // Check if the input is exactly 10 digits and a valid number
                            if (input.Length == 10 && double.TryParse(input, out patientPhone))
                            {
                                break; // Exit the loop if the input is valid
                            }

                            // If the input is not valid, display an error message
                           
                            AnsiConsole.MarkupLine("[red underline]Invalid phone number. Please enter a 10-digit valid number.[/]");
                            
                        }

                        Console.Write("Enter password for registration: ");
                        string regPassword = AnsiConsole.Prompt(
                        new TextPrompt<string>("Enter [green]password[/]?")
                            .PromptStyle("red")
                            .Secret());

                        while (!IsPasswordValid(regPassword))
                        {

                            AnsiConsole.MarkupLine("[red bold underline]Invalid password: 1. Atleast 8 Characters 2. Atleast 1 Capital Letter 3. Atleast 1 Digit 4. Atleast 1 Special Character[/]");
                            Console.Write("Enter password for registration: ");
                            regPassword = AnsiConsole.Prompt(
                            new TextPrompt<string>("Enter [green]password[/]?")
                                .PromptStyle("red")
                                .Secret());
                        }

                        Console.Write("Confirm Password: ");
                        string conPassword = AnsiConsole.Prompt(
                        new TextPrompt<string>("Enter [green]password[/]?")
                            .PromptStyle("red")
                            .Secret());

                        while (conPassword != regPassword)
                        {
                            AnsiConsole.MarkupLine("[red underline]Password does not match[/]");                        
                            Console.Write("Confirm Password: ");
                            conPassword = AnsiConsole.Prompt(
                            new TextPrompt<string>("Enter [green]password[/]?")
                                .PromptStyle("red")
                                .Secret());
                        }

                        Console.Write("Enter Patient Age for registration: ");
                        int patientAge;

                        while (!int.TryParse(Console.ReadLine(), out patientAge) || patientAge < 0 || patientAge > 101)
                        {
                            AnsiConsole.MarkupLine("[red underline]Invalid age. Please enter a valid age.[/]");

                            Console.Write("Enter Patient Age for registration: ");
                        }


                        bool registrationResult = LoginRegBAL.RegisterPatient(patientName, patientEmail, patientPhone, regPassword, patientAge);

                        if (registrationResult)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registration successful!\n");
                            Console.ResetColor();
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[red underline]Registration failed. Please try again.[/]");

                        }
                        Login();

                        break;

                    case "2.Patient Login":
                        Login();
                        break;

                    case "3.Forgot Password":
                        Console.Write("Enter Your Email: ");
                        string forgEmail = Console.ReadLine();
                        bool validEmail = LoginRegBAL.forgotPassword(forgEmail);
                        while (!validEmail)
                        {
                            AnsiConsole.MarkupLine("[red underline]Incorrect Email[/]");
                  
                            Console.Write("Enter Your Email: ");
                            forgEmail = Console.ReadLine();
                            validEmail = LoginRegBAL.forgotPassword(forgEmail);
                        }

                        // Generate random 4-digit OTP
                        Random rnd = new Random();
                        int otpValue = rnd.Next(1000, 10000); // Generate a random number between 1000 and 9999
                        string rndOtp = otpValue.ToString("D4"); // Convert to a string with leading zeros if necessary
                        FileStream fileStreamObject = new FileStream("C:\\Users\\sanchitk\\Desktop\\OTPAuthentication.txt", FileMode.OpenOrCreate, FileAccess.Write);
                        using (StreamWriter streamWriterObject = new StreamWriter(fileStreamObject))
                        {
                            streamWriterObject.WriteLine("Your OTP is: " + rndOtp);
                            streamWriterObject.Close();
                        }
                        fileStreamObject.Close();
                        Console.Write("Enter OTP: ");
                        string otp = Console.ReadLine();
                        while (otp != rndOtp)
                        {
                            AnsiConsole.MarkupLine("[red underline]Incorrect OTP[/]");

                            Console.Write("Enter OTP: ");
                            otp = Console.ReadLine();
                        }
                        Console.Write("Enter Password: ");
                        string forgPassword = AnsiConsole.Prompt(
                        new TextPrompt<string>("Enter [green]password[/]?")
                            .PromptStyle("red")
                            .Secret());
                        while (!IsPasswordValid(forgPassword))
                        {
         
                            AnsiConsole.MarkupLine("[red bold underline]Invalid password: 1. Atleast 8 Characters 2. Atleast 1 Capital Letter 3. Atleast 1 Digit 4. Atleast 1 Special Character[/]");                   
                            Console.Write("Enter password for registration: ");
                            forgPassword = AnsiConsole.Prompt(
                            new TextPrompt<string>("Enter [green]password[/]?")
                                .PromptStyle("red")
                                .Secret());
                        }
                        Console.Write("Confirm Password: ");
                        conPassword = AnsiConsole.Prompt(
                        new TextPrompt<string>("Enter [green]password[/]?")
                            .PromptStyle("red")
                            .Secret());

                        while (conPassword != forgPassword)
                        {
                            AnsiConsole.MarkupLine("[red bold underline]Password does not match[/]");
                            Console.Write("Confirm Password: ");
                            conPassword = AnsiConsole.Prompt(
                            new TextPrompt<string>("Enter [green]password[/]?")
                                .PromptStyle("red")
                                .Secret());
                        }
                        bool forgotPasswordResult = LoginRegBAL.changePassword(forgEmail, forgPassword);

                        if (forgotPasswordResult)
                        {
                            AnsiConsole.MarkupLine("[green underline]Password Change successful![/]");
               
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[red underline]Password Change failed. Please try again.[/]");
                           
                        }
                        Login();
                        break;


                    case "4.Go Back":
                        Console.Clear();
                        return;
                }

            }
        }
      
        static bool ContainsNumbers(string input)
        {
            // Using regular expression to check for numeric characters
            return Regex.IsMatch(input, @"\d");
        }
       
        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.Contains(".com"); // Check if ".com" is present
            }
            catch
            {
                return false;
            }

        }

        static bool IsPasswordValid(string password)
        {
            // Password requirements: Minimum 8 characters, at least 1 uppercase letter, 1 special character, 1 digit
            string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }
      
        static void Login()
        {
            //  login
            Console.WriteLine("~~~~~~~~~~~~~~~ Login ~~~~~~~~~~~~~~~");
            Console.Write("Enter email for login: ");
            string loginUsername = Console.ReadLine();


            // Console.Write("Enter password for login: ");
            string loginPassword = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter [green]password[/]?")
                .PromptStyle("red")
                .Secret());


            //string loginPassword = Console.ReadLine();

            bool loginResult = LoginRegBAL.ValidateLogin(loginUsername, loginPassword);

            if (loginResult)
            {
                AnsiConsole.MarkupLine("[green underline]Login successful![/]");
                AnsiConsole.MarkupLine($"[green underline]~~~~~~~~~~~~ Welcome {loginUsername} ~~~~~~~~~~~~ [/]");
               
            }
            else
            {
                AnsiConsole.MarkupLine("[red underline]Invalid login credentials. Please try again.[/]");
              
            }
            int userId = LoginRegBAL.GetPatientId(loginUsername, loginPassword);

            if (userId != -1)
            {
                Console.WriteLine($"User with username '{loginUsername}' logged in successfully! (UserID: {userId})\n");
                // PatientRatingMenu(userId);
                PatientMainMenu(userId);
                Console.ReadLine();

            }
            else
            {
                AnsiConsole.MarkupLine("[red underline]Invalid email or password. Login failed.[/]");
                Console.ReadLine();
            }


        }


        //------------------------------------------------------------ADMIN LOGIN AND MAIN MENU

        static void AdminLogin()
        {
            //  login
            Console.WriteLine("~~~~~~~~~~~~~~~ Login ~~~~~~~~~~~~~~~");
            Console.Write("Enter Admin Email for login: ");
            string loginUsername = Console.ReadLine();
            Console.Write("Enter Admin Password for login: ");
            string loginPassword = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter [green]password[/]?")
                .PromptStyle("red")
                .Secret());

            bool loginResult = LoginRegBAL.ValidateAdmin(loginUsername, loginPassword);

            if (loginResult)
            {
                AnsiConsole.MarkupLine("[green underline]Login successful![/]");
                AnsiConsole.MarkupLine($"[blue]~~~~~~~~~~~~ Welcome {loginUsername} ~~~~~~~~~~~~ [/]");
                
            }
            else
            {
                AnsiConsole.MarkupLine("[red underline]Invalid login credentials. Please try again.[/]");
            }
            int adminId = LoginRegBAL.GetAdminId(loginUsername, loginPassword);

            if (adminId != -1)
            {
                Console.WriteLine($"Admin with email id: '{loginUsername}' logged in successfully! (AdminID: {adminId})\n");

                AdminMainMenu();

            }
            else
            {
                AnsiConsole.MarkupLine("[red underline]Invalid username or password. Login failed.[/]");
                
            }

        }

        static void AdminMainMenu()
        {
            try
            {
                Console.Clear();
                while (true)
                {
                    var rule1 = new Spectre.Console.Rule();
                    rule1.Style = Style.Parse("seagreen1");
                    AnsiConsole.Write(rule1);
                    Console.WriteLine();
                    AnsiConsole.Write(new FigletText("MediTrack Admin Panel").Color(Color.Yellow).Centered());
                    Console.WriteLine();
                    AnsiConsole.Write(rule1);
                    Console.WriteLine();

                     var choice = AnsiConsole.Prompt(
                     new SelectionPrompt<string>()
                    .Title("[lightcoral blink]Please select from below options[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                    .AddChoices(new[] {
                                                "1.Admin Operations on Medicine Inventory",
                                                "2.Admin Operations on Patient Records",
                                                "3.Logout and Exit Admin Panel",

                    }));

                    // Echo the fruit back to the terminal
                    switch (choice)
                    {
                        case "1.Admin Operations on Medicine Inventory":
                            Console.Clear();
                            DisplayAdminChoicesForMedicineOperations();
                            break;

                        case "2.Admin Operations on Patient Records":
                            Console.Clear();
                            DisplayAdminChoicesForPatientRecordOperations();
                            break;

                        case "3.Logout and Exit Admin Panel":
                            Console.Clear();
                            return;

                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }



        //-------------------------------------------------------------PATIENT MENU
        static void PatientMainMenu(int userId)
        {
            while (true)
            {
           

                var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[lightcoral blink]Please select from below options[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(new[] {
                                        "1.Buy Medicines",
                                        "2.View Rating and Rate Medicines",
                                        "3.Logout and Go Back",
                }));
                switch (choice)
                {
                    case "1.Buy Medicines":
                        PatientBuyMedicineMenu(userId);
                        break;
                    case "2.View Rating and Rate Medicines":
                        PatientRatingMenu(userId);
                        break;
                    case "3.Logout and Go Back":
                        Console.Clear();
                        return;
                }
            }
        }

        static void PatientRatingMenu(int userId)
        {

            while (true)
            {

               var choice = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
               .Title("[lightcoral blink]Please select from below options[/]")
               .PageSize(10)
               .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
               .AddChoices(new[] {
                                        "1.Give Rating and Reviews",
                                        "2.See Rating of any Medicine",
                                        "3.Search Ratings for any medicine",
                                        "4.Update Rating or Reviews",
                                        "5.Delete rating",
                                        "6.See all ratings",
                                        "7.Go Back"
               }));

                switch (choice)
                {
                    case "1.Give Rating and Reviews":
                        Console.Clear();
                        DataTable allRatings3 = GetAllRatings();
                        DisplayRatings(allRatings3);
                        GiveRatings(userId);
                        break;

                    case "2.See Rating of any Medicine":
                        Console.Clear();
                        DisplayMedicineTable();
                        Console.Write("Enter Medicine Id : ");
                        int ID = Convert.ToInt32(Console.ReadLine());
                        MedicineRatingsDisplay(ID);
                        break;

                    case "3.Search Ratings for any medicine":
                        Console.Clear();
                        DisplayMedicineTable();
                        Console.WriteLine("\n ---------- Search Bar ---------- \n ");
                        Console.Write("Enter a search term: ");
                        string search = Console.ReadLine();
                        DisplaySearchRatings(search);
                        break;

                    case "4.Update Rating or Reviews":
                        Console.Clear();
                        DataTable allRatings1 = GetAllRatings();
                        DisplayRatings(allRatings1);
                        Console.Write("Enter Rating Id : ");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Medicine new Rating : ");
                        decimal rating = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Enter new Feedback : ");
                        string feedback = Console.ReadLine();
                        UpdateRatingAndFeedback(Id, userId, rating, feedback);
                        break;

                    case "5.Delete rating":
                        DataTable allRatings2 = GetAllRatings();
                        DisplayRatings(allRatings2);
                        Console.Write("Enter Rating Id to be deleted : ");
                        int ratingId = Convert.ToInt32(Console.ReadLine());
                        DeleteRating(ratingId);
                        break;

                    case "6.See all ratings":
                        Console.Clear();
                        DisplayMedicineTable();
                        DataTable allRatings = GetAllRatings();
                        DisplayRatings(allRatings);
                        break;

                    case "7.Go Back":
                        Console.Clear();
                        return;

                }
            }

        }

        static void PatientBuyMedicineMenu(int userId)
        {

            while (true)
            {

                var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("[lightcoral blink]Please select from below options[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .AddChoices(new[] {
                                        "1.Display Medicine",
                                        "2.Search Medicine",
                                        "3.Add Medicine to MediCart",
                                        "4.Display MediCart",
                                        "5.Delete Medicine From MediCart",
                                        "6.Update Medicine Quantity From MediCart",
                                        "7.Confirm and Generate Bill",
                                        "8.Go Back"
                }));


                switch (choice)
                {
                    case "1.Display Medicine":
                        //DisplayMedicineMenu For displaying all the medicine in MediTrack .
                        DisplayMedicineTable();
                        break;

                    case "2.Search Medicine":
                        //DisplaySearchResult for searching the  required medicine which is entered by user.
                        SearchMedicines();
                        break;

                    case "3.Add Medicine to MediCart":
                        //PatientAddMedicineToMediCart for adding medicine to Cart.
                        PatientAddMedicineToMediCart(userId);
                        break;

                    case "4.Display MediCart":
                        // PatientDisplayMediCart for display the Medicine in Cart Of the Patient
                        Console.Clear();
                        PatientDisplayMediCart(userId);
                        break;

                    case "5.Delete Medicine From MediCart":
                        // PatientRemoveMediCart for Removing the Medicine from Cart Of the Patient
                        PatientRemoveMediCart(userId);
                        break;

                    case "6.Update Medicine Quantity From MediCart":
                        UpdatePatientMedicineQuantityMenu(userId);
                        //PatientUpdateMedicineQuantity used for updating the quanity of medicine in the medicart
                       
                        break;
                    case "7.Confirm and Generate Bill":
                        //GenerateBill is for confirming the order and then generating the bill for the cart items

                        GenerateBill(userId);
                        break;

                    case "8.Go Back":
                        Console.Clear();
                        return;
                }
            }
        }




        //----------------------------------------------------------------SANA BUY MEDICINES OPERATION


        static void UpdatePatientMedicineQuantityMenu(int userId)
        {

            while (true)
            {
                var updatechoice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[lightcoral blink]Please select from below options[/]")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
        .AddChoices(new[] {
                                        "1.Add Medicine Quantity",
                                        "2.Subtract Medicine Quantity",
                                        "3.Replace Medicine Quantity",
                                        "4.Go Back"
        }));


                switch (updatechoice)
                {
                    case "1.Add Medicine Quantity":
                        Console.Clear();
                        AnsiConsole.MarkupLine("[blue]This Funcionality Adds the Medicine Quantity For Particular Medicine[/]");
                        PatientUpdateQuantity(userId, updatechoice);
                        break;

                    case "2.Subtract Medicine Quantity":
                        Console.Clear();
                        AnsiConsole.MarkupLine("[blue]This Funcionality Subtracts the Medicine Quantity For Particular Medicine[/]");
                        PatientUpdateQuantity(userId, updatechoice);
                        break;

                    case "3.Replace Medicine Quantity":
                        Console.Clear();
                        AnsiConsole.MarkupLine("[blue]This Funcionality Replaces the Medicine Quantity For Particular Medicine[/]");
                        PatientUpdateQuantity(userId, updatechoice);
                        break;

                    case "4.Go Back":
                        Console.Clear();
                        return;


                }

            }
        }
        static void PatientDisplayMediCart(int patientId)
        {

            var rule = new Spectre.Console.Rule($"[darkorange]Medicine Cart for Patient ID: {patientId}[/]");
            rule.Style = Style.Parse("green");
            AnsiConsole.Write(rule);

            Console.WriteLine();

            DataTable cartItemsTable = PatientBAL.GetCartItems(patientId);

            var table = new Table();
            table.Border = TableBorder.DoubleEdge;
            table.Centered();
            table.AddColumn(new TableColumn("[orangered1 underline]Cart ID[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Medicine ID[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Medicine Name[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Brand Name[/]").Centered());
            table.AddColumn(new TableColumn("[orangered1 underline]Category Name[/]").Centered());
            table.AddColumn(new TableColumn("[green underline]Cost[/]").Centered());
            table.AddColumn(new TableColumn("[green underline]Quantity[/]").Centered());
            table.AddColumn(new TableColumn("[green underline]Total Price[/]").Centered());

            foreach (DataRow row in cartItemsTable.Rows)
            {           
                table.AddRow($"{row["medicine_cart_id"]}", $"{row["medicine_id"]}", $"{row["medicine_name"]}", $"{row["brand_name"]}", $"{row["medicine_category_name"]}", $"[darkolivegreen1_1]{row["cost"]}[/]", $"{row["quantity"]}", $"{row["total_price"]}");

            }

            AnsiConsole.Write(table);

            Console.WriteLine();
            var rule1 = new Spectre.Console.Rule();
            rule1.Style = Style.Parse("green");
            AnsiConsole.Write(rule1);
            Console.WriteLine();


        }
       
        static void PatientAddMedicineToMediCart(int patientId)
        {
            Console.Clear();
            DisplayMedicineTable();
            Console.WriteLine("");
            Console.Write("Enter the Medicine ID to add to the MediCart: ");
            int medicineId = Convert.ToInt32(Console.ReadLine()); ;


            Console.Write("Enter the quantity to add to the MediCart: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            // Add the Medicine to the cart

            bool addToCartResult = PatientBAL.AddToMediCart(patientId, medicineId, quantity);

            if (addToCartResult)
            {
                Console.WriteLine("Medicine added to the MediCart successfully!\n");
            }
            else
            {
                Console.WriteLine("Failed to add Medicine to the MediCart. Please try again.\n");
            }
        }
       
        static void PatientRemoveMediCart(int patientId)
        {
            Console.Clear();
            PatientDisplayMediCart(patientId);

            // for Remove Medicine from Cart
            Console.Write("Enter the Medicine ID to delete medicine from the MediCart: ");
            int medicineid = Convert.ToInt32(Console.ReadLine()); ;

            bool removeFromCartResult = PatientBAL.RemoveFromMediCart(patientId, medicineid);

            if (removeFromCartResult)
            {
                Console.WriteLine("Medicine deleted from the MediCart successfully!\n");
            }
            else
            {
                Console.WriteLine("Failed to delete Medicine from the MediCart. Please try again.\n");
            }
        }

        static void PatientUpdateQuantity(int patientId, string updatechoice)
        {
            PatientDisplayMediCart(patientId);

            Console.Write("Enter Medicine ID to update medicine in MediCart:");
            int medicineId = Convert.ToInt32(Console.ReadLine());
         

            // Check if the medicine exists for the patient
            bool medicineExists = PatientBAL.MedicineExistsForPatient(patientId, medicineId);

            if (medicineExists)
            {
                Console.Write("Enter the quantity to update to the MediCart: ");
                int uquantity = Convert.ToInt32(Console.ReadLine());
                while (uquantity < 0)
                {
                    AnsiConsole.MarkupLine("[red underline]Medicine Quantity can not be negative[/]");
                    Console.Write("Enter Medicine Quantity to update to the MediCart:  ");
                    uquantity = Convert.ToInt32(Console.ReadLine());
                }

                // Update the quantity in the cart

                bool updateToCartResult = PatientBAL.UpdateCartItemQuantity(patientId, medicineId, uquantity, updatechoice);

                if (updateToCartResult)
                {
                    Console.WriteLine($"Quantity updated successfully for Medicine ID {medicineId}.");
                }
                else
                {
                    Console.WriteLine($"Failed to update quantity for Medicine ID {medicineId}.");
                }
            }
            else
            {
                Console.WriteLine($"Medicine ID {medicineId} not found for Patient ID {patientId}.");
            }

            AnsiConsole.MarkupLine("[blue]Updated Medicine Cart[/]");
            PatientDisplayMediCart(patientId);
        }

        static void GenerateBill(int patientId)
        {
            Console.Clear();
            // Retrieve cart items from BAL
            DataTable cartItemsTable = PatientBAL.GetCartItems(patientId);

            Console.WriteLine("\t\t\t\t=============================================================================");
            Console.WriteLine("\t\t\t\t|                         MediTrack Pharmacy Bill                           |");
            Console.WriteLine("\t\t\t\t=============================================================================");
            Console.WriteLine($"\t\t\t\t| Patient ID: {patientId,-30}     Date: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}  |");
            Console.WriteLine("\t\t\t\t|                                                                           |");
            Console.WriteLine("\t\t\t\t+---------------------------------------------------------------------------+");
            Console.WriteLine("\t\t\t\t| Medicine Name                 |  Price             | Quantity             |");
            Console.WriteLine("\t\t\t\t+---------------------------------------------------------------------------+");

            decimal totalAmount = 0;


            foreach (DataRow row in cartItemsTable.Rows)
            {
                string productName = row["medicine_name"].ToString();
                decimal price = decimal.Parse(row["total_price"].ToString());
                int quantity = Convert.ToInt32(row["quantity"]);

                decimal total = price;
                totalAmount += total;

                Console.WriteLine($"\t\t\t\t| {productName,-29} | {price,-18:C} | {quantity,-20} |");
            }

            Console.WriteLine("\t\t\t\t+---------------------------------------------------------------------------+");
            Console.WriteLine($"\t\t\t\t| Total Amount:{totalAmount,29:C}                                |");
            Console.WriteLine("\t\t\t\t=============================================================================\n");
            string enteredPassword = AnsiConsole.Prompt(
            new TextPrompt<string>($"Enter [green blink]Password[/] For Paying the bill for amount : {totalAmount} - ")
           .PromptStyle("red")
           .Secret());

            if (PatientBAL.PasswordCheck(patientId, enteredPassword))
            {
                Console.WriteLine();
                AnsiConsole.MarkupLine("[green blink]Paid successfully![/]");
                PatientBAL.ClearCart(patientId);
            }
            else
            {
                AnsiConsole.MarkupLine("[red underline]Invalid password. Access denied.[/]");
            }

        }





        //------------------------------------------------------------------------------- SAKSHI MEDICINE RATINGS ----------------------------------------------------

        static void GiveRatings(int userId)
        {
            //Console.OutputEncoding = Encoding.UTF8;


            Console.Write("Enter Medicine ID : ");
            int medicine_id = Convert.ToInt32(Console.ReadLine());


            Console.Write("Enter Your rating in number[0-5] : ");
            decimal userRate = Convert.ToDecimal(Console.ReadLine());
            while(userRate <0 || userRate > 5)
            {
                AnsiConsole.MarkupLine("[red underline]Enter Rating Between 0-5[/]");
                Console.Write("Enter Your rating in number[0-5] : ");
                userRate = Convert.ToDecimal(Console.ReadLine());
            }


     


            Console.Write("You Rated : ");

            String starHtml = GenerateStarString(userRate);

            AnsiConsole.MarkupLine(starHtml);


            Console.Write("Enter Your Review : ");
            string feedback = Console.ReadLine();

            int patient_Id = userId;
            RatingBAL.GiveRatings(medicine_id, patient_Id, userRate, feedback, userId);

        }

        static string GenerateStarString(decimal rating)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int filledStars = (int)Math.Round(rating);
            int emptyStars = 5 - filledStars;

            StringBuilder stars = new StringBuilder();


            for (int i = 0; i < filledStars; i++)
            {
                // stars.Append("★");
                stars.Append("[yellow blink]*[/]");
            }

            for (int i = 0; i < emptyStars; i++)
            {
                //stars.Append("☆");
                stars.Append("[grey]*[/]");
            }
            Console.ResetColor();
            return stars.ToString();

        }

        static void MedicineRatingsDisplay(int Id)
        {
            try
            {

                var rule = new Spectre.Console.Rule("[darkorange]Medicine Rating Table[/]");
                rule.Style = Style.Parse("green");
                AnsiConsole.Write(rule);
                Console.WriteLine();

                DataTable searchResults = RatingBAL.MedicineRatings(Id);

                var table = new Table();
                table.Border = TableBorder.DoubleEdge;
                table.Centered();
                table.AddColumn(new TableColumn("[orangered1 underline]Rating ID[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Medicine ID[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Medicine Name[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Cost[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Overall Rating[/]").Centered());
                


                if (searchResults.Rows.Count > 0)
                {
                    DataRow row = searchResults.Rows[0];
                    decimal rating = Convert.ToDecimal(row["average_rating"]);

                    table.AddRow($"{row["rating_Id"]}",$"{row["medicine_id"]}", $"{row["medicine_name"]}", $"{row["cost"]}", $"{row["average_rating"]}  {GenerateStarString(rating)}");

                }

                AnsiConsole.Write(table);

                Console.WriteLine();
                var rule1 = new Spectre.Console.Rule();
                rule1.Style = Style.Parse("green");
                AnsiConsole.Write(rule1);
                Console.WriteLine();

                int count = 1;
                Console.WriteLine("Reviews : ");
                foreach (DataRow row in searchResults.Rows)
                {

                    string feedback = row["feedback"].ToString();

                    Console.WriteLine(count + " : " + feedback);
                    count++;
                }
                Console.ResetColor();
                Console.WriteLine();



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DisplaySearchResults: {ex.Message}");
            }
        }

        static void UpdateRatingAndFeedback(int Id, int patientId, decimal rating, string feedback)
        {
            try
            {
             

                Console.ForegroundColor = ConsoleColor.Yellow;

                RatingBAL.MedicineUpdatedRatingAndFeedback(Id, patientId, rating, feedback);

                DataTable searchResults = RatingBAL.MedicineRatings(Id);

            
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateRatingAndFeedback: {ex.Message}");
            }
        }

        static void DisplaySearchRatings(string search)
        {
            try
            {

                var rule = new Spectre.Console.Rule($"[darkorange]Search Results for '{search}'[/]");
                rule.Style = Style.Parse("green");
                AnsiConsole.Write(rule);
                Console.WriteLine();

                DataTable searchResults = RatingBAL.SearchMedicine(search);
                var table = new Table();
                table.Border = TableBorder.DoubleEdge;
                table.Centered();
                table.AddColumn(new TableColumn("[orangered1 underline]Rating ID[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Medicine ID[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Medicine Name[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Generation[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Cost[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Rating[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Reviews[/]").Centered());
                

                foreach (DataRow row in searchResults.Rows)
                {

                    decimal rating = Convert.ToDecimal(row["average_rating"]);
                
                    table.AddRow($"{row["rating_Id"]}", $"{row["medicine_id"]}", $"{row["medicine_name"]}", $"{row["generation"]}", $"{row["cost"]}", $"{row["average_rating"]}    {GenerateStarString(rating)}",  $"{row["feedback"]}");

                }

                AnsiConsole.Write(table);
                Console.WriteLine();
                var rule1 = new Spectre.Console.Rule();
                rule1.Style = Style.Parse("green");
                AnsiConsole.Write(rule1);
                Console.WriteLine();





            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DisplaySearchResults: {ex.Message}");
            }
        }

        static void DeleteRating(int ratingId)
        {
            try
            {
                RatingBAL.DeleteRating(ratingId);
                Console.WriteLine($"Rating with Rating Id {ratingId} deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting rating: {ex.Message}");
            }
        }

        static DataTable GetAllRatings()
        {
            try
            {
                return RatingBAL.GetAllRatings();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all ratings: {ex.Message}");
                return null;
            }
        }

        static void DisplayRatings(DataTable ratings)
        {
            if (ratings != null && ratings.Rows.Count > 0)
            {

                var rule = new Spectre.Console.Rule("[darkorange]Diplay Ratings[/]");
                rule.Style = Style.Parse("green");
                AnsiConsole.Write(rule);
                Console.WriteLine();
                var table = new Table();
                table.Border = TableBorder.DoubleEdge;
                table.Centered();
                table.AddColumn(new TableColumn("[orangered1 underline]Rating ID[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Medicine ID[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Medicine Name[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Patient ID[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Patient Name[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Rating[/]").Centered());
                table.AddColumn(new TableColumn("[orangered1 underline]Reviews[/]").Centered());
      
                foreach (DataRow row in ratings.Rows)
                {

                    decimal rating = Convert.ToDecimal(row["rating"]);

                    table.AddRow($"{row["rating_Id"]}", $"{row["medicine_id"]}", $"{row["medicine_name"]}", $"{row["patient_Id"]}", $"{row["patient_name"]}", $"{row["rating"]}   {GenerateStarString(rating)}", $"{row["feedback"]}");
                    
                }


                AnsiConsole.Write(table);
                Console.WriteLine();
                var rule1 = new Spectre.Console.Rule();
                rule1.Style = Style.Parse("green");
                AnsiConsole.Write(rule1);
                Console.WriteLine();

          }
            else
            {
                Console.WriteLine("No ratings found.");
            }
        }






        //--------------------------------------------------------- GUEST MAIN MENU
        static void GuestMainMenu()
        {

            while (true)
            {

               var choice = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
               .Title("[lightcoral blink]Please select from below options[/]")
               .PageSize(10)
               .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
               .AddChoices(new[] {
                                        "1.View All Medicines",
                                        "2.Search Medicines",
                                        "3.Go Back"
               }));

                switch (choice)
                {
                    case "1.View All Medicines":
                        Console.Clear();
                        DisplayMedicineTable();
                        break;

                    case "2.Search Medicines":
                        Console.Clear();
                        SearchMedicines();
                        break;

                    case "3.Go Back":
                        Console.Clear();
                        return;

                }
            }
        }











    }
}








