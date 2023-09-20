# Appointment Scheduling System
A Windows Forms Application (.NET Framework) appointment + customer scheduling system written in C#. This program integrates with
a MySQL database. Using the GUI, users can add/update/delete customers from the database, as well as add/update/delete appointments
for customers.

![](https://github.com/IamJesseP/C969Jesse/blob/master/DemoGif.gif)

## Demo Video
<div style="margin:auto;">
    <a href="https://www.loom.com/share/5a4bc554b1ed410580b5319b95110c99">
    </a>
    <a href="https://www.loom.com/share/5a4bc554b1ed410580b5319b95110c99">
      <img style="max-width:300px" src="https://cdn.loom.com/sessions/thumbnails/5a4bc554b1ed410580b5319b95110c99-with-play.gif">
    </a>
  </div>
  
### Technologies
* C#
* .NET Windows Form Application
* MySQL

### Tools
* Visual Studio
* Git and GitHub
* Windows 11


## Functionality
* #### A login form that:
  * Initializes a new sample database if one does not exist, or connects to an existing database.
  * Determines the user’s location and translate log-in and error control messages (e.g., “The username and password did not match.”) into the user’s language and in one additional language.

* #### Provide the ability to add, update, and delete customer records in the database, including name, address, and phone number. 

* #### Provide the ability to add, update, and delete appointments, capturing the type of appointment and a link to the specific customer record in the database.

* #### Provide the ability to view the calendar by month and by week. 

* #### Provide the ability to automatically adjust appointment times based on user time zones and daylight-saving time.

* #### provide reminders and alerts 15 minutes in advance of an appointment, based on the user’s log-in.

* #### Provide the ability to track user activity by recording timestamps for user log-ins in a .txt file. Each new record appends to the log file if the file already exists.

* #### Exception controls for:
  * Scheduling an appointment outside business hours
  * Scheduling overlapping appointments
  * Entering nonexistent or invalid customer data
  * Entering an incorrect username and password
 
## What I learned

* C# Fundamentals
* Type safety
* Windows Forms
* .NET Framework
* Model View Controller(MVC) System Design
* OOP principles like Encapsulation, Data Abstraction, Polymorphism and Inheritance
* Improved understanding code structure and readability

### Academic
Course: C969 Software II: Advanced C# at WGU
