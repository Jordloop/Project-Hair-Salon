
# Hair Salon


#### By Jordan Loop; Date of current version: 6/22/2017

## Description

#### This program allows the user to add stylists, and add/update/delete a stylist's clients.

## Setup/Installation Requirements

1. Clone git repo.
2. Create database:<br>
    In SQLCMD:<br>
    CREATE DATABASE hair_salon; > GO > USE hair_salon > GO > CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255), client_id INT)); > GO > CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255));<br>
3. Create test database:<br>
    In SQLCMD:<br>
    CREATE DATABASE hair_salon_test; > GO > USE hair_salon_test > GO > CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255), client_id INT)); > GO > CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255));<br>
4. Start local Server:<br>
    In PowerShell:<br>
      dnx kestrel<br>
5. In any modern browser go to "localhost:5004"

## Known Bugs

No know bugs.

## Questions/Concerns or advice?

Contact me at jordanloop@gmail.com

## Technologies Used

* Nancy
* ASP.NET 5
* C#
* HTML
* Bootstrap
* Xunit

### License

Copyright (c) 2017 Jordan Loop, Epicodus

## Specs

| Behavior handled<br>By this program:                      | Input example<br>When it receives: | Output example<br>It should return:                         |
|-----------------------------------------------------------|------------------------------------|-------------------------------------------------------------|
| Client is able to view all stylists.                      | Click "View Stylists" button.      | List of all stylists.                                       |
| Client is able to add new stylist from all stylists page. | Click "New Stylist" button.        | A form to add a new stylist.                                |
| Client submits "New Stylist" form.                        | Click "Submit" button.             | Returned to all stylists page.                              |
| Client is able to delete stylist.                         | Click "Remove Stylist" button.     | Returned to all stylists page.                              |
| Client is able to see details about a specific stylists.  | Click "Anne McCaffrey" link.       | Stylist's name, rent, cost and list of clients.             |
| Client is able to go to "Client" page.                    | Clicks "Client" button.            | List of all clients.                                        |
| Client is able to add a new client.                       | Clicks "Add Client" button.        | Form to add a new client, and drop down to assign stylist.  |
| Client submits "Add Client" form.                         | Click "Submit" button.             | Returned to home page.                                      |
| Client is able to remove clients.                         | Click "Remove Client" button.      | Returned to client page with list of all clients.           |
| Client is able to update a client's name.                 | Click "Edit Name" button.          | A form to edit client's name.                               |
| Client submits "Edit Name" form.                          | Click "Submit" button.             | Returned to client page with updated client name.           |
