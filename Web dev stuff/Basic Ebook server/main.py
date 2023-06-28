from flask import Flask, request, jsonify
from flask_restful import Resource
from flask_talisman import Talisman
import os

app = Flask(__name__)
# Create a content security policy and apply it
csp = {
    'default-src': '\'self\''
}
talisman = Talisman(app, content_security_policy=csp)

#TODO: add some string input cleaning

@app.route("/")
@app.route("/Check")
def welcome():
    return "Hello from basic ebook server"

#Book methods
@app.route("/post_book/<string:book_name>", methods = ["POST"])
@app.route("/post_book/<string:book_name>/<string:folder>", methods = ["POST"])
def Upload_book(book_name, folder = "Misc"):
    return 501

@app.route("/delete_book/<string:book_name>", methods = ["DELETE"])
def Remove_book(book_name):
    return 501

#TODO: figure out why it doesn't like the folder param, add a try catch that throws 404 if no file
@app.route("/rename_book/<string:book_name>/<string:new_name>")
@app.route("/rename_book/<string:book_name>/<string:new_name>/<string:folder>", methods = ["PUT"])
def Rename_book( book_name, new_name, folder = 'Misc'):
    if request.method == "POST":
        return 405
    old_name = 'Books/' + folder + '/' + book_name
    new_name = 'Books/' + folder + '/' + new_name
    os.rename(old_name, new_name)
    return "done"

#Folder methods
@app.route("/post_folder/<string:folder_name>/<content>", methods = ["POST"])
def Upload_folder(folder_name, contents):
    return 501

@app.route("/delete_folder/<string:folder_name>/<bool:delete_content>", methods = ["DELETE"])
def Delete_folder():
    return 501

@app.route("/rename_folder/<string:folder_name>/<string:new_name>", methods = ["PUT"])
def Rename_folder(folder_name, new_name):
    return 501

#Library management functions
@app.route("/create_folder/<string:folder_name>", methods = ["POST"])
def Create_folder(folder_name):
    return 501

@app.route("/move_book_to_folder/<string:old_folder_name>/<string:new_folder_name>/<string:book_name>", methods = ["PUT"])
def Move_book_to_folder(old_folder_name, new_folder_name, book_name):
    return 501

#Thumbnail management functions
@app.route("/reassign_thumb/<string:folder_name>/<string:book_name>/<string:thumb>", methods = ["PUT"])
def Reasign_thumb(folder_name, book_name, thumb):
    return 501

@app.route("/clear_thumbs/<string:option>", methods = ["PUT"])
def Clear_thumbs(option = "Clear"):
    return 501

#Misc option functions
@app.route("/toggle_dl/<string:option>/<string:code>", methods = ["PUT"])
def Toggle_dls(option, code):
    return 501

@app.route("/toggle_readers/<string:option>/<string:code>", methods = ["PUT"])
def Toggle_readers(option, code):
    return 501

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
    app.run(debug = True)
