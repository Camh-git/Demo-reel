import shutil
from flask import Flask, request, jsonify
from flask_restful import Resource
from flask_talisman import Talisman
from flask_wtf import FlaskForm
from wtforms import FileField
from flask_cors import CORS, cross_origin
import os

app = Flask(__name__)
# Create a content security policy and apply it
csp = {
    'default-src': '\'self\''
}
talisman = Talisman(app, content_security_policy=csp)

#TODO: add some string input cleaning
#TODO: add logging
#TODO: add security

@app.route("/")
@app.route("/Check")
def welcome():
    return "Hello from basic ebook server"

#Book methods
@app.route("/post_book/<string:book_name>", methods = ["POST"])
@app.route("/post_book/<string:book_name>/<string:folder>", methods = ["POST"])
def Upload_book(book_name, folder = "Misc"):
    return 501

@app.route("/delete_book/<string:folder>/<string:book_name>")
def Delete_book(folder, book_name):
    target = 'Books/' + folder + '/' + book_name
    try:
        os.remove(target)
        resp = jsonify(success = True, status = 200)
    except Exception:
        resp = jsonify(success = False, status = 404, path = target)

    return resp

@app.route("/rename_book/<string:folder>/<string:book_name>/<string:new_name>")
def Rename_book(folder, book_name, new_name):
    if request.method == "POST":
        return 405
    old_name = 'Books/' + folder + '/' + book_name
    new_name = 'Books/' + folder + '/' + new_name
    try:
        os.rename(old_name, new_name)
        resp = jsonify(success = True, status = 200, path = new_name)
    except Exception:
        resp = jsonify(success = False, status = 404, path = old_name)
    
    return resp

#Folder methods
@app.route("/post_folder/<string:folder_name>/<content>", methods = ["POST"])
def Upload_folder(folder_name, contents):

    return 501


@app.route("/delete_folder/<string:folder_name>/<string:delete_content>")
def Delete_folder(folder_name,delete_content):
    if delete_content.upper() == "YES":
        try:
            shutil.rmtree("Books/"+folder_name)
            resp = jsonify(success = True, status = 200, path = "Books/" + folder_name)
        except Exception:
            resp = jsonify(success = False, status = 500, body = "Error removing all books from: Books/" + folder_name)
    else:
        #Moving all the contents of this dir to misc
        try:
            for book in os.listdir("Books/"+folder_name):
                shutil.move("Books/"+folder_name+"/"+book,"Books/Misc/")            
        except Exception:
            resp = jsonify(success = False, status = 304, body = "Error moving all books from: Books/" + folder_name + " To Books/misc prior to deletion")
            return resp
        
        #Delete the dir
        try:
            os.rmdir("Books/" + folder_name)
            resp = jsonify(success = True, status = 200, path = "Books/" + folder_name, body = "Deleted: " + folder_name + ". All books moved to Books/misc")
        except Exception:
            resp = jsonify(success = False, status = 500, body = "Error deleting folder: Books/" + folder_name)
    
    return resp

#TODO: figure out why specifying a put method on the renames causes errors
@app.route("/rename_folder/<string:folder_name>/<string:new_name>")
def Rename_folder(folder_name, new_name): 
    
    old_name = 'Books/' + folder_name
    new_name = 'Books/' + new_name
    try:
        os.rename(old_name, new_name)
        resp = jsonify(success = True, status = 200, path = new_name)
    except Exception:
        resp = jsonify(success = False, status = 404, path = old_name)
        
    return resp

#Library management functions
@app.route("/create_folder/<string:folder_name>")
def Create_folder(folder_name):
    if not os.path.exists("Books/" + folder_name):
        try:
            os.makedirs("Books/" + folder_name)
            resp = jsonify(success = True, status = 201)
        except Exception:
            resp = jsonify(success = False, status = 500, body = "Failed to create dir after determining that the name was available")
    else:
        resp = jsonify(success = False, status = 500, body = "Failed to create dir, name already in use")

    return resp

@app.route("/move_book_to_folder/<string:old_folder_name>/<string:new_folder_name>/<string:book_name>")
def Move_book_to_folder(old_folder_name, new_folder_name, book_name):
    old_path = "Books/" + old_folder_name + "/" + book_name
    new_path = "Books/" + new_folder_name + "/" + book_name

    if os.path.isfile(old_path):
        if os.path.exists("Books/" + new_folder_name):
            try:
                shutil.move(old_path,new_path)
                resp = jsonify(success = True, status = 200)
            except Exception:
                resp = jsonify(success = False, status = 500, body = "Failed to move book")
        else:
            resp = jsonify(success = False, status = 404, body = "Failed to move book, target folder does not exist")
    else:
        resp = jsonify(success = False, status = 404, body = "Failed to move book, Failed to find source")
    
    return resp

#Thumbnail management functions
@app.route("/reassign_thumb/<string:folder_name>/<string:book_name>/<string:thumb>", methods = ["PUT"])
def Reasign_thumb(folder_name, book_name, thumb):
    return 501

#TODO: add the re-population function
@app.route("/clear_thumbs/<string:option>")
def Clear_thumbs(option = "Clear"):
    if option == "clear":
        try:
            for img in os.listdir("Assets/Images/Thumbnail_cache"):
                os.remove("Assets/Images/Thumbnail_cache/"+img)
            resp = jsonify(success = True, status = 200)
        except Exception:
            resp = jsonify(success = False, status = 500, body = "Failed to clear cache")
    elif option == "":
        resp = jsonify(success = False, status = 501, body = "Not implemented")

    return resp

#Misc option functions
@app.route("/toggle_dl/<string:option>/<string:code>", methods = ["PUT"])
def Toggle_dls(option, code):
    return 501

@app.route("/toggle_readers/<string:option>/<string:code>", methods = ["PUT"])
def Toggle_readers(option, code):
    return 501

#TODO: add trys, return a propper response
#http://127.0.0.1:5000/lists/1.1.1.1/whitelist/add
@app.route("/lists/<address>/<string:list>/<string:option>")
def Manage_ip_list(address,list,option):
     #Get data from the right list
    data = ""
    if list.upper() == "WHITELIST":
        with open("Assets/Whitelist.txt","r") as file:
            data = file.read()
    
    elif list.upper() == "BLACKLIST":
        with open("Assets/Blacklist.txt","r") as file:
            data = file.read()
    else:
        return "Bad list option: " + list 
    
    #If adding and adress check it exists then add if not, or remove if selected
    if(option.upper() == "ADD"):
        if address not in data:
            data += ("\n" + str(address))
    elif(option.upper() == "REMOVE"):
        data = data.replace(address,"")
    else:
        return "Bad whitelist action: " + option
            
    #Write the newly changed data to the correct file
    if list.upper() == "WHITELIST":
        with open("Assets/Whitelist.txt","w") as file:
            file.write(data)
    elif list.upper() == "BLACKLIST":
        with open("Assets/Blacklist.txt","w") as file:
            file.write(data)
    else:
        return "Bad list option: " + list  

    return "done" #TO DO: replace with 200
    

@app.route('/', defaults={'path': ''})
@app.route('/<path:path>')
def Catch_all(path):
    return "Invalid path: " + path, 400

if __name__ == "__main__":
    print("launching...")
    print("To access the server's UI from this machine go to: localhost:88/Simple_Ebook_server/Home.html")
    print("To access the server's UI from another machine substitute the localhost portion with the computer's IP")
    print("")
    app.run(debug = True)
