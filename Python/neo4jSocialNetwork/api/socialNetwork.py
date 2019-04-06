#Imports
import sys
#sys.path.append('../')
sys.path.insert(0, 'D:\\GitHub\\Private\\Python\\neo4jSocialNetwork')
print(sys.path)
import backend.dBUsers as users
import backend.dBPages as pages

from flask import Flask

#TODO
#Maybe split up this script?

#Flask app
app = Flask(__name__)

@app.route('/')
def index():
    return "Welcome to the best social network ever!"

@app.route('/get/user/all/', methods = ['GET'])
def showAllUsers():
    userList = []
    allUsers = users.getAll()

    for item in allUsers:
        userList.append('{0}'.format(item[0]["name"]))

    return ("<p>All Users:</p><p>" + "</p><p>".join(userList) + "</p>")

#Note: If there are more users with the same name, this will get all.
# Only the first will be shown! (Should be fixed)
@app.route('/get/user/<name>', methods = ['GET'])
def getByName(name):
    result = users.getByName(name)
    
    return result[0][0]["name"]

@app.route('/get/user/<name>/friends', methods = ['GET'])
def getAllFriend(name):
    friendsList = []
    allFriends = users.getAllFriends(name)

    for item in allFriends:
        friendsList.append('{0} are friends with {1}'.format(item[0]["name"], item[2]["name"]))

    return ("<p>" + "</p><p>".join(friendsList) + "</p>")

#@app.route('/get/user/likes/<name>', methods = ['GET'])

#@app.route('/get/user/posts/<name>', methods = ['GET'])

@app.route('/post/user/<name>', methods = ['POST', 'GET'])
def createUser(name):
    users.createUser(name)

    return 'User {0} created!'.format(name)

@app.route('/post/user/friendship/<name>/<friend>', methods = ['POST', 'GET'])
def addFriend(name, friend):
    users.addFriend(name, friend)

    return '{0} and {1} are now friends!'.format(name, friend)

@app.route('/post/user/<name>/<page>', methods = ['POST', 'GET'])
def addLike(name, page):
    users.addLike(name, page)
    
    return 'User {0} likes {1}'.format(name, page)

#@app.route('/post/user/<name>/<post>', methods = ['POST'])

@app.route('/delete/user/<name>', methods = ['DELETE', 'GET'])
def deleteUser(name):
    users.deleteUser(name)

    return 'User {0} deleted!'.format(name)

@app.route('/delete/user/friendship/<name>/<friend>', methods = ['DELETE', 'GET'])
def removeFriend(name, friend):
    users.removeFriend(name, friend)

    return 'User {0} removes {1} as friend!'.format(name, friend)

@app.route('/delete/user/like/<name>/<page>', methods = ['DELETE', 'GET'])
def removeLike(name, page):
    users.removeLike(name, page)
    return 'User {0} stopped liking {1}'.format(name, page)

#@app.route('/delete/user/<name>/<post>', methods = ['DELETE'])

@app.route('/post/page/<name>', methods = ['POST', 'GET'])
def createPage(name):
    pages.createPage(name)

    return 'Page {0} created!'.format(name)

@app.route('/delete/page/<name>', methods = ['DELETE', 'GET'])
def deletePage(name):
    pages.deletePage(name)

    return 'Page {0} deleted!'.format(name)

if __name__ == "__main__":
    app.run()