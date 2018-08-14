# Tracking System
Sample tracking system which features: an agent's SPA dashboard, a manager's panel and an administrator's control board.

Metrics Track represents an end-to-end system for data collection. Its primary goal is to measure the workflow's volume within a company, aggregate the collected data and distribute it to its final recipients.

For this purpose the application grants three types of profiles: for the agents, the managers and the system's administrators. All transactions selected by the agents have already been mapped by an administrator. Once submitted by the agents these transactions are available to the managers at the time of the submission. 

A transaction contains several features like process, line of business, activity, etc. It also stores all other calculated basic KPIs like handling time, SLA hours, SLA target, etc. 

The process starts with the user’s registration. Once registered the administrator receives an e-mail notification about the new joiner. The administrator has to approve the new account by assigning it to a particular manager. This way the user obtains an “agent” role and is able to see the dashboard and the daily transactions list mapped to the selected by the agent country. The agent will receive an e-mail notification about the assignment and will be invited to log into the application. A manager could be granted with “manager” permissions by the administrator after the registration as well.

Demo:
[http://metrics-track.azurewebsites.net/](http://metrics-track.azurewebsites.net/)

Used technologies and packages:
-   ASP.NET Core
-   SQL server
-   Entity framework
-   Razor
-   jQuery
-   AJAX
-   Boostrap
-   MailKit
-   X.PagedList
-	DotNetCore.NPOI
-   AutoМapper
-   Azure Key Vault

Noticeable features:
-   Service and Data layers
-   Environment variables split
-   Multithreading
-   Partial views
-	Layouts separation
-   MVC Areas
-	Razor Pages
-   Dependency Injection
-   SQL Injection, XSS, CSRF, parameter tampering, etc. prevention
-   Class constants
-   Session booster
-   Session timeout notification
-   AjaxOnly Attribute
-	Validation Attribute
-	ResultFilter Attribute
-   Layout Validation Attribute
-   ValidateAntiForgeryToken Middleware
-   SessionExtensions
-   AutoMapperProfile
-	Animejs animation
-	On demand Excel Export