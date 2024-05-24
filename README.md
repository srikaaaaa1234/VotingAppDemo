This online voting app is a simple demonstration of online voting.
It would have options of adding Voters, candidates and voting. All of CURD operations gets immediately reflected on the app drop downs.

Tech Stack : .NET8 , React, NodeJs, Vite, MS-SQL

We can easily scale this to support Azure Docker Images, CI/CD , PingOne Authentication. Current API Backend folder can be divided to Multiple layers to provide support for CQRS Pattern.

Core, Data, Application, Queries, Repositories.

Its a migration first approach model to create database.

Below are the steps to run:

1. Open VS Code
2. Ctl + Shift + P, Command window, Choose Git: Clone
3. Enter the URL
4. Choose Repo Directory in local
5. After cloning gets completed.
6. Open terminal, run below commands (Ensure dotnet 8 is installed along with Node Js)
7. dotnet clean
8. dotnet build
9. To debug run below command
10. dotnet watch run
11. ![image](https://github.com/srikaaaaa1234/VotingAppDemo/assets/39992347/11e7528a-9c75-4590-9e18-c15b463c1275)
12. then Open new terminal - switch to Frontend folder.
13. npm install
14. npm run dev

Then in browser we can add voters, candidates.
Similarly vote for candidate. (In vite.config.js) https can be set to false for dev purpose

Add voter screenshot

![image](https://github.com/srikaaaaa1234/VotingAppDemo/assets/39992347/1548a0e8-c3e5-45be-9d68-7418594a1bab)



