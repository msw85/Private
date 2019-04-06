#Imports
import sys
#sys.path.append('../')
sys.path.insert(0, 'D:\\Python\\Privat\\Projekter\\neo4jSocialNetwork')
print(sys.path)
import backend.dBUsers as users
#import .backend.dBPages

from flask import Flask

#Flask app
app = Flask(__name__)

@app.route('/')
def index():
    return "Welcome to the best social network ever!"

@app.route('/get/user/all/', methods = ['GET'])
def showAllUsers():
    userList = []
    test = users.getAll()

    for item in test:
        userList.append('{0}'.format(item[0]["name"]))

    return ("<p>All Users:</p><p>" + "</p><p>".join(userList) + "</p>")

#@app.route('/get/user/<name>', methods = ['GET'])

#@app.route('/get/user/<name>/friends', methods = ['GET'])

#@app.route('/get/user/<name>/likes', methods = ['GET'])

#@app.route('/get/user/<name>/posts', methods = ['GET'])

@app.route('/post/user/<name>', methods = ['POST', 'GET'])
def createUser(name):
    users.createUser(name)

    return 'User {0} created!'.format(name)

@app.route('/post/user/friendship/<name>/<friend>', methods = ['POST', 'GET'])
def addFriend(name, friend):
    users.addFriend(name, friend)

    return '{0} and {1} are now friends!'.format(name, friend)

#@app.route('/post/user/<name>/post', methods = ['POST'])

@app.route('/delete/user/<name>', methods = ['DELETE', 'GET'])
def deleteUser(name):
    users.deleteUser(name)

    return 'User {0} deleted!'.format(name)

@app.route('/delete/user/friendship/<name>/<friend>', methods = ['DELETE', 'GET'])
def removeFriend(name, friend):
    users.removeFriend(name, friend)

    return 'User {0} removes {1} as friend!'.format(name, friend)

#@app.route('/delete/user/<name>/<post>', methods = ['DELETE'])

if __name__ == "__main__":
    app.run()