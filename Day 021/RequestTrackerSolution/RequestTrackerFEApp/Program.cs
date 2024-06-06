using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        private static Employee? CurrentLoggedInEmployee;
        private readonly IEmployeeLoginBL employeeLoginBL;
        private readonly IRequestBL requestBL;
        private readonly IRequestSolutionBL solutionBL;
        private readonly ISolutionFeedbackBL feedbackBL;

        public Program()
        {
            this.employeeLoginBL = new EmployeeLoginBL();
            this.requestBL = new RequestBL();
            this.solutionBL = new RequestSolutionBL(requestBL);
            this.feedbackBL = new SolutionFeedbackBL();
            CurrentLoggedInEmployee = null;
        }

        static async Task Main(string[] args)
        {
            Program program = new Program();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Welcome to Request Tracker");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.WriteLine("-----------------------------------------------");
                string? choice = program.GetChoiceFromUser();

                switch (choice)
                {
                    case "1":
                        await program.GetLoginDetails();
                        break;
                    case "2":
                        await program.GetRegisterDetails();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        string GetChoiceFromUser()
        {
            Console.Write("Enter your choice: ");
            string? choice = Console.ReadLine();
            return choice;
        }
        async Task GetLoginDetails()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Login");
            Console.WriteLine("-----------------------------------------------");
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string? password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id, password);
        }
        async Task GetRegisterDetails()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Register");
            Console.WriteLine("-----------------------------------------------");
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string? password = Console.ReadLine() ?? "";
            await EmployeeRegisterAsync(id, password);
        }
        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password, Id = username };
            var result = await employeeLoginBL.Login(employee);

            if (result != null)
            {
                CurrentLoggedInEmployee = result;
                await Console.Out.WriteLineAsync("Login Success");
                Console.WriteLine("-----------------------------------------------");
                Task.Delay(2000);
                if (CurrentLoggedInEmployee.Role == "Admin")
                    await ManageAdminRequests();
                else
                    await ManageUserRequests();
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
        }
        async Task EmployeeRegisterAsync(int username, string password)
        {
            string role = "User";
            if (CurrentLoggedInEmployee != null && CurrentLoggedInEmployee.Role == "Admin")
                role = "Admin";

            Employee employee = new Employee() { Password = password, Id = username, Role = role };
            var result = await employeeLoginBL.Register(employee);
            if (result != null)
            {
                await Console.Out.WriteLineAsync("Registration Success with ID " + result.Id);
            }
            else
            {
                Console.Out.WriteLine("Registration Failed");
            }
        }

        async Task ManageUserRequests()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("User Request Management Menu");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View Request Status");
                Console.WriteLine("3. View Solutions");
                Console.WriteLine("4. Give Feedback");
                Console.WriteLine("5. Respond to Solution");
                Console.WriteLine("6. Logout");
                Console.WriteLine("-----------------------------------------------");
                string? choice = GetChoiceFromUser();

                switch (choice)
                {
                    case "1":
                        await AddRequest();
                        break;
                    case "2":
                        await ViewUserRequestDetails();
                        break;
                    case "3":
                        await ViewUserSolutions();
                        break;
                    case "4":
                        await GiveFeedback();
                        break;
                    case "5":
                        await RespondToSolution();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        async Task AddRequest() //user & admin
        {
            Console.Write("Request Message: ");
            string? requestMessage = Console.ReadLine() ?? "";
            DateTime currentDateTime = DateTime.Now;
            DateTime requestDate = currentDateTime;

            Request request = new Request
            {
                RequestMessage = requestMessage,
                RequestDate = requestDate,
                RequestStatus = "Opened",
                RequestRaisedBy = CurrentLoggedInEmployee.Id,
                RequestClosedBy = CurrentLoggedInEmployee?.Id ?? 0
            };

            var AddUserRequest = await requestBL.OpenRequest(request);
            Console.WriteLine("Request Added Successfully with ID : " + AddUserRequest);
        }

        async Task ViewUserRequestDetails() //user
        {
            var requestDetails = await requestBL.GetAllRequestsById(CurrentLoggedInEmployee.Id);
            if (requestDetails == null)
            {
                Console.WriteLine("Request not found!");
                return;
            }
            foreach (var reqdet in requestDetails)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(reqdet.ToString());
                Console.WriteLine("-----------------------------------------------");
            }
        }

        async Task<bool> ViewUserSolutions() //user
        {
            Console.WriteLine("All the requests for the logged in user are:");
            await ViewUserRequestDetails();
            Console.WriteLine("Enter Request Number to View Solutions:");
            int requestNumber = Convert.ToInt32(Console.ReadLine());
            var solution = await solutionBL.GetAllUserRequestSolutions(CurrentLoggedInEmployee.Id, requestNumber);
            if (solution == null)
            {
                Console.WriteLine("No solution found for this request.");
                return false;
            }
            foreach (var sol in solution)
            {
                if (sol.RequestId == requestNumber)
                {
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine(sol.ToString());
                    Console.WriteLine("-----------------------------------------------");
                }
            }
            return true;
        }

        async Task GiveFeedback() //user & admin
        {
            bool isSolutionPresent = await ViewUserSolutions();
            if (!isSolutionPresent)
            {
                return;
            }
            Console.WriteLine("Enter the solution ID to give feedback:");
            int solutionId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your rating (out of 5): ");
            int rating = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Enter your remarks: ");
            string remarks = Console.ReadLine() ?? "";

            var feedback = new SolutionFeedback
            {
                Rating = rating,
                Remarks = remarks,
                SolutionId = solutionId,
                FeedbackBy = CurrentLoggedInEmployee.Id,
                FeedbackDate = DateTime.Now
            };

            await feedbackBL.AddFeedback(feedback);
            Console.WriteLine("Feedback submitted successfully.");
        }

        async Task RespondToSolution() //user
        {
            ViewUserSolutions();
            Console.WriteLine("Enter the solution ID to respond:");
            int solutionId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your response: ");
            string response = Console.ReadLine() ?? "";

            var solution = await solutionBL.RespondToSolution(solutionId, response);
            if (solution == null)
            {
                Console.WriteLine("Solution not found.");
                return;
            }

            Console.WriteLine("Response submitted successfully.");
        }

        async Task ManageAdminRequests()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Admin Request Management Menu");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View Request Status (All Requests)");
                Console.WriteLine("3. View Solutions (All Solutions)");
                Console.WriteLine("4. Give Feedback (Only for requests raised by them)");
                Console.WriteLine("5. Respond to Solution (Only for requests raised by them)");
                Console.WriteLine("6. Provide Solution");
                Console.WriteLine("7. Mark Request as Closed");
                Console.WriteLine("8. View Feedbacks (Only feedbacks given to them)");
                Console.WriteLine("9. Logout");
                Console.WriteLine("-----------------------------------------------");

                string? choice = GetChoiceFromUser();

                switch (choice)
                {
                    case "1":
                        await AddRequest();
                        break;
                    case "2":
                        await ViewAllRequests();
                        break;
                    case "3":
                        await ViewAllSolutions();
                        break;
                    case "4":
                        await GiveFeedback();
                        break;
                    case "5":
                        await RespondToSolution();
                        break;
                    case "6":
                        await ProvideSolution();
                        break;
                    case "7":
                        await MarkRequestAsClosed();
                        break;
                    case "8":
                        await ViewFeedbacks();
                        break;
                    case "9":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        async Task ProvideSolution() //admin
        {
            ViewAllRequests();
            Console.WriteLine("Enter Request Number to Provide Solution:");
            int requestNumber = Convert.ToInt32(Console.ReadLine());
            var res = await requestBL.GetRequestById(requestNumber);
            if (res.RequestStatus == "Closed")
            {
                Console.WriteLine("Request is already closed.");
                return;
            }
            Console.WriteLine("Enter Solution Description:");
            string solutionDescription = Console.ReadLine() ?? "";

            var solution = new RequestSolution
            {
                SolutionDescription = solutionDescription,
                RequestId = requestNumber,
                SolvedBy = CurrentLoggedInEmployee?.Id ?? 0,
            };

            await solutionBL.AddRequestSolution(solution);
            Console.WriteLine("Solution provided successfully.");
        }

        async Task MarkRequestAsClosed() //admin
        {
            await GetAllOpenRequests();

            Console.WriteLine("Enter Request Number to be Marked as Closed:");
            int requestNumber = Convert.ToInt32(Console.ReadLine());
            var request = await requestBL.GetRequestById(requestNumber);

            //close last solution
            var solution = request.RequestSolutions.ToList();

            if (solution.Count == 0)
            {
                Console.WriteLine("No solution found for this request.");
            }
            else
            {
                await UpdateSolutionStatus(solution);
            }
            request.ClosedDate = DateTime.Now;
            await requestBL.UpdateRequest(requestNumber, "Closed");
            Console.WriteLine("Request marked as closed successfully.");
        }
        async Task UpdateSolutionStatus(IList<RequestSolution> solutions)
        {
            Console.Out.WriteLine("Solutions Given for the selected reuqest: ");

            foreach (var solution in solutions)
            {
                Console.Out.WriteLine(solution);
            }

            Console.WriteLine("Which one of the solution helped you to solve ur request?");
            int solutionId = Convert.ToInt32(Console.ReadLine());

            await solutionBL.UpdateSolutionAsSolved(solutionId);

            return;

        }
        async Task GetAllOpenRequests()
        {
            var openRequests = await requestBL.GetAllOpenRequests();

            foreach (var openRequest in openRequests)
            {
                Console.WriteLine(openRequest);
            }
        }
        async Task ViewFeedbacks() //admin
        {
            var allSolutions = await solutionBL.GetAllAdminRequestSolutions();
            var solutionIds = new List<int>();
            foreach(var solution in allSolutions)
            {
                if(solution.SolvedBy == CurrentLoggedInEmployee?.Id)
                    solutionIds.Add(solution.SolutionId);
            }

            var allFeedbacks = await feedbackBL.GetAllAdminFeedbacks(solutionIds);

            foreach (var item in allFeedbacks)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(item.ToString());
                Console.WriteLine("-----------------------------------------------");
            }
        }

        async Task ViewAllRequests() //admin
        {
            var allRequests = await requestBL.GetAllRequests();
            if (allRequests == null || allRequests.Count == 0)
            {
                Console.WriteLine("No requests found.");
                return;
            }
            foreach (var request in allRequests)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(request.ToString());
                Console.WriteLine("-----------------------------------------------");
            }
        }

        async Task ViewAllSolutions() //admin
        {
            var allSolutions = await solutionBL.GetAllAdminRequestSolutions();
            if (allSolutions == null || allSolutions.Count == 0)
            {
                Console.WriteLine("No solutions found.");
                return;
            }

            foreach (var solution in allSolutions)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(solution.ToString());
                Console.WriteLine("-----------------------------------------------");
            }
        }

    }
}