Project Overview
This is a Desktop Pharmacy Management System built with C# and Windows Forms, designed to streamline pharmacy operations including inventory management, staff administration, product cataloging, customer records, and order processing.

Core Architecture |
The system follows a modular UI design with role-based access:

Main Entry Point |
Program.cs: Launches the application with FormLoad as the initial splash/loading screen
Authentication Layer
Login.cs: User authentication interface,
Register.cs: New user registration,
ChangePswrd.cs: Password modification,
ForgotPswrd.cs: Password recovery

Authentication Layer |
Login.cs: User authentication interface,
Register.cs: New user registration,
ChangePswrd.cs: Password modification,
ForgotPswrd.cs: Password recovery

Role-Based Dashboards

1. Admin Dashboard (AdminMain.cs) |
Full system access and management,
Navigation to all modules with animated indicator
Dashboard with statistics,
Color theme customization (Light/Dark modes),
User logout functionality,
2. Staff Dashboard (StaffMain.cs) |
Staff member interface with limited permissions
