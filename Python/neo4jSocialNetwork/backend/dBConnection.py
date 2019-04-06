#Imports
from neo4jrestclient.client import GraphDatabase

#DB Connection
def getDBConnection():
    db = GraphDatabase('http://localhost:7474', username = 'neo4j', password = 'passWD')

    return db