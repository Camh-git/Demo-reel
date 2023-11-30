# My current project
### I am currently continuing work on my ebook server project, which was put on hiatus during the tech returners program (see weather app group project)
The aims of the project at this stage are to:
  - Implement a management system for the library using a flask API.
  - Replace the old php code with python (converting to a newer LAMP stack).
  - Modify the layout and CSS to work on a wide range of screen sizes.
  - Bring the older, less polished code up to standard.


### The project can be found here:
**https://github.com/Camh-git/Simple_Ebook_Server**

### Running the project
To run the server and website you will need to take the following steps:
  1. Install a LAMP stack with php (will change in future), I followed this tutorial: https://www.youtube.com/watch?v=ZDcbb_VjIQs
  2. Install python version 3.9 or later
  3. Download the files from github and copy them into the web root, which should be at: /var/www/html/
  4. Open a command prompt and CD into the /var/www/html/Simple_Ebook_Server directory
  5. Run the command: `export FLASK_APP="BookAPI.py"` to point flask at the correct file.
  6. Run the command: `flask run --host=0.0.0.0` to run the API. **NOTE: the project is still WIP and this will change**
  7. With the API now running, naviagte to: *Device IP*/Simple_Ebook_Server/Home.html
  8. Enjoy looking around and reading the supplied public domain books.
