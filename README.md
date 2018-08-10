# Tracking System
Sample tracking system which features an agent's dashboard, a manager's and an admin panel.

Metrics Track represents an end-to-end system for data collection. Its primary goal is to measure the workflow volume within a company, aggregate the collected data and distribute it to its final recipients.

For this purpose the application grants three types of profiles: for the agents, the managers and the system’s administrators. All transactions selected by the agents have already been mapped by the administrator. Once submitted by the agents these transactions are available to their direct managers at the time of the submission. 

A transaction contains several features like process, line of business, activity, etc. It also stores all other calculated basic KPIs like handling time, SLA hours, SLA target, etc. 

The process starts with the user’s registration. Once registered the administrator receives an e-mail notification about the new joiner. The administrator has to approve the new account by assigning it to a particular team leader. This way the user obtains an “agent” role and is able to see the dashboard and the daily transactions list mapped to the selected by the agent country. The agent will receive an e-mail notification about the assignment and will be invited to log into the application. A manager could be granted with “manager” permissions by the administrator after the registration as well.

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
-   AutoМapper
-   Azure Key Vault

Noticeable features:
-   Service layer
-   Data layer
-   Environment variables
-   Multithreading
-   Partial views
-	Layouts separation
-   MVC Areas
-   Dependency Injection
-   SQL Injection, XSS, CSRF, parameter tampering, etc. prevention
-   Class constants
-   Session booster
-   Session timeout notification
-   AjaxOnlyAttribute
-   Layout Validation Attribute
-   ValidateAntiForgeryTokenMiddleware
-   SessionExtensions
-   AutoMapperProfile
-	Animejs animation