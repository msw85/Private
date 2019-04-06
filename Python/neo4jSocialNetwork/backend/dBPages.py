#Imports
import backend.dBConnection as conn
from neo4jrestclient import client

def createPage(name):
    #Implement other attributes
    result = None #True/False
    
    db = conn.getDBConnection()
    query = 'CREATE (p:Page {{name: "{0}"}})'.format(name)
    db.query(query)

    return result

def getAll():
    pages = None

    return pages

def getByName(name):
    page = None

    return page

def getAllLikes(name):
    likes = None

    return likes

def addAdmin(name, adminName):
    result = None

    return result

def deletePage(name):
    result = None
    db = conn.getDBConnection()
    query = 'MATCH (p:Page) WHERE p.name = "{0}" DELETE p'.format(name)
    db.query(query)

    return result

def deleteAdmin(name, adminName):
    result = None

    return result