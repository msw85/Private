#Imports
import backend.dBConnection as conn
from neo4jrestclient import client

#TODO
# Make a seperate module for like, post etc functions.
# Usefull return values with status of the operation.

#Direct user functions
def createUser(userName):
    #Implement other attributes
    result = None #True/False
    
    db = conn.getDBConnection()

    label = db.labels.create('User')
    user = db.nodes.create(name = userName)
    label.add(user)
    return result

def getAll():
    db = conn.getDBConnection()
    query = 'MATCH (u:User) RETURN u'

    users = db.query(query, returns = (client.Node))

    return users

def getByName(name):
    db = conn.getDBConnection()
    query = 'MATCH (u:User) WHERE u.name = "{0}" RETURN u'.format(name)

    user = db.query(query, returns = (client.Node))

    return user

def deleteUser(name):
    result = None #True/False

    db = conn.getDBConnection()
    query = 'MATCH (u:User) WHERE u.name = "{0}" DELETE u'.format(name)
    db.query(query)

    return result

#User friend functions
def addFriend(name, friendName):
    result = None #True/False
    db = conn.getDBConnection()
    query = 'MATCH (u1:User),(u2:User) WHERE u1.name = "{0}" AND u2.name = "{1}" CREATE (u1)-[r:friend]->(u2)'.format(name, friendName)
    db.query(query)

    return result

def getAllFriends(name):
    friends = None

    return friends

def removeFriend(name, friendName):
    result = None #True/False
    db = conn.getDBConnection()
    query = 'MATCH (u1:User)-[r:friend]-(u2:User) WHERE u1.name = "{0}" AND u2.name = "{1}" DELETE r'.format(name, friendName)
    db.query(query)

    return result

#User pagelike functions
def addLike(name, pageName):
    result = None #True/False

    return result

def getAllLikes(name):
    likes = None

    return likes

def deleteLike(name, pageName):
    result = None #True/False

    return result

#User post functions
def addPost(name, post):
    result = None #True/False

    return result

def getAllPosts(name):
    posts = None

    return posts

def deletePost(name, post):
    result = None #True/False

    return result