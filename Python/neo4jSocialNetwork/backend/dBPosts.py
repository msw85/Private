#Imports
import backend.dBConnection as conn
from neo4jrestclient import client

#TODO
# Implement other functions if needed
# Timestamps are needed to make a "facebook wall" feel

def createPost(message):
    #Implement other attributes
    result = None #True/False
    
    db = conn.getDBConnection()
    query = 'CREATE (p:Post {{message: "{0}"}})'.format(message)
    db.query(query)

    return result

def getAllPosts():
    db = conn.getDBConnection()
    query = 'MATCH (u:User)-[r:post]-(p:Post) RETURN u, type(r), p'
    posts = db.query(query, returns = (client.Node, str, client.Node))

    return posts

def deletePost(message):
    result = None
    db = conn.getDBConnection()
    query = 'MATCH (p:Post) WHERE p.message = "{0}" DELETE p'.format(message)
    db.query(query)

    return result