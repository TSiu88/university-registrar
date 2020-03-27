# _[University Registrar](https://github.com/TSiu88/university-registrar)_

#### _Registration Tracker, 03.23.2020_

#### _By: **Tiffany Siu and Andriy Veremyeyev**_

[![Project Status: Inactive – The project has reached a stable, usable state but is no longer being actively developed; support/maintenance will be provided as time allows.](https://www.repostatus.org/badges/latest/inactive.svg)](https://www.repostatus.org/#inactive)
![LastCommit](https://img.shields.io/github/last-commit/tsiu88/university-registrar)
![Languages](https://img.shields.io/github/languages/top/tsiu88/university-registrar)
[![MIT license](https://img.shields.io/badge/License-MIT-orange.svg)](https://lbesson.mit-license.org/)

---
## Table of Contents
1. [Description](#description)
2. [Setup/Installation Requirements](#setup/installation-requirements)
    - [Requirements to Run](#requirements-to-run)
    - [Instructions](#instructions)
    - [Other Technologies Used](#other-technologies-used)
3. [User Stories](#user-stories)
4. [Known Bugs](#known-bugs)
5. [Support and Contact Details](#support-and-contact-details)
6. [License](#license)
---
## Description

This application tracks students, courses, and departments.  Includes Identity authentication for adding students.

#### 3/23/20 Work from Home Summary
- University Registrar
- Struggles: 
  - Third many-to-many class and connections to other classes/controllers
  - Connecting student's completed courses in a department

## Setup/Installation Requirements

_This program requires .NET Core SDK to run. [Here is a free tutorial](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-c-and-net) for installing .NET on Mac or Windows 10 from the [official website](https://dotnet.microsoft.com/download/dotnet-core/)._ 

_This program also makes use of SQL databases. We recommend using MySQL Workbench to build your databases. [Here is a free tutorial](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql) for installing MySQL WorkBench and MySQL Community Server on Mac (using links [Mac1](https://dev.mysql.com/downloads/file/?id=484914) and [Mac2](https://dev.mysql.com/downloads/file/?id=484391)) or [Windows 10](https://dev.mysql.com/downloads/file/?id=484919)._

### Requirements to Run
* _.NET Core_
* _ASP.NET Core MVC_
* _MySQL Workbench_
* _MySQL Community Server_
* _Entity Framework_
* _Command Prompt_
* _Web Browser_

### Instructions

*This application may be viewed by:*

1. Download and install .NET Core from the [official website](https://dotnet.microsoft.com/download/dotnet-core/)
2. Download and install MySQL Workbench and Community Server for Mac or Windows by following the instructions [here](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).
3. Click clone the [repository](https://github.com/TSiu88/university-registrar.git) from my [GitHub page](https://github.com/TSiu88) to copy the repository link
4. Use a command line interface to type `git clone (repository-link-here)` to copy the project into the current folder and then move into the repository's directory that was just created with `cd (project-name-here)`
5. Start up a local server by opening MySQL Workbench and adding a `MySQL Connections` using the default IP address and Port (IP 127.0.0.1, Port 3306), username (root), and password from setup.
6. Run `dotnet restore` and `dotnet build` in command line interface of the repository's main project directory
7. Run `dotnet run` to start up the program in the command line interface
8. Type the URL listed under "Now listening on:" into a web browser to run

## Other Technologies Used
* _C#_
* _HTML_
* _CSS_
* _MSTest_
* _Razor_
* _Markdown_

## User Stories
* As a registrar, I want to enter a student, so I can keep track of all students enrolled at this University. I should be able to provide a name and date of enrollment.
* As a registrar, I want to enter a course, so I can keep track of all of the courses the University offers. I should be able to provide a course name and a course number (ex. HIST100).
* As a registrar, I want to be able to assign students to a course, so that teachers know which students are in their course. A course can have many students and a student can take many courses at the same time.
* As a registrar, I want to be able to create departments. A student can be assigned to a department when they declare their major and a course can be assigned to a department when it is created.
* As a registrar, I want to be able to list out all of the courses or all of the students in a particular department, so that I can inform the counselors which departments need more students and which need more courses.
* As a registrar, I want to change a student's file to show that they have completed a course, so that I can see if they need to take the course again.
* As a registrar, I want to list out all of the courses a student has taken, so that I can see if they have met their degree requirements.
<!-- * As a registrar, I want to see how many students have not completed courses in any particular departments, so that I can tell the administration which departments need help. -->

## Known Bugs

_There are currently no known bugs in this program_

## Support and contact details
_If there are any question or concerns please contact us at our emails: [Tiffany Siu](mailto:tsiu88@gmail.com) and [Andriy Veremyeyev](mailto:#). Thank you._

### License

*This software is licensed under the MIT license*

Copyright (c) 2020 **_Tiffany Siu, Andriy Veremyeyev_**
