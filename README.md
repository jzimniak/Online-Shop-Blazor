# BlazorShopSite

BlazorShopSite is an online shop created with .Net 5 (Blazor)

## Requirements
- Visual Studio with .Net 5
- SQL Server

## Installation
- Database
	1. Login to SQL Server.
	2. Right click on Databases Folder (In Object Explorer).
	3. Click Import Data-tier Application...
	4. Choose import from local disk.
	5. Browse db.bacpac file (in Database folder).
	6. Press Next and follow the instructions.
	7. After done this, you should have 12 tables and 17 stored procedures in your DB.
	
- Project

	1. Open project.
	2. In appsettings.json set your connectionString to SQL Server and run the project.
	3. Go to the page '/admin-panel'.
	4. Click Zaloguj się, and use 'admin' for login and 'password' for password.
	5. You should now have a permission to use ProductManagement.
	6. Go to 'Dodatkowe funkcje' (If you have connectionString with status 'niepołączono' then you need to change connectionString, because it is wrong).
	7. If every row has a green status 'Istnieje', then you did everything correct. 
	
## More Information about Project	
	
- Page: /admin-panel  -  product management
- Product information is stored in json files to avoid too many SQL requests.
- Opinions of the product (text, not given stars) is stored only in json (It's impossible to restore opinions after delete opinions.json).
- distinct.json is used in filtrcomponent and when you are adding/editing products.
- topmenu.json is basically to render dropdown menu on top of the page.
- backups folder is for files that were deleted via product management (It's for safety reason when you accidentally delete json via ProductManagement).
- Services/Cart storing information about products in Cart.
- Services/SimpleUserInfo storing information about User (is user logged/username etc.).
- Services/Refresh_Component - the most comfortable way to call StateHasChanged() in another Component.
- Services/DistinctService - storing information for filtr component and product management.
	
## License
[MIT](https://choosealicense.com/licenses/mit/)	