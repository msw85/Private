#Imports
from neo4jrestclient import client
from neo4jrestclient.client import GraphDatabase

#EXAMPLE DB SETUP
#DB Connection
db = GraphDatabase('http://localhost:7474', username = 'neo4j', password = 'passWD')

#Nodes and labels
user = db.labels.create('User')
user1 = db.nodes.create(name = 'Putin')
user2 = db.nodes.create(name = 'Trump')

user.add(user1, user2)

missile = db.labels.create('Missile')
missile1 = db.nodes.create(name = 'Hellfire')
missile2 = db.nodes.create(name = 'Satan')

missile.add(missile1, missile2)

#Relationships
user1.relationships.create('hearts', missile1)
user2.relationships.create('hearts', missile2)

user1.relationships.create('caresses', user2)

#QUERY DB
query1 = 'MATCH (u:User)-[r:hearts]->(m:Missile) WHERE u.name = "Putin" RETURN u, type(r), m'
query2 = 'MATCH (u:User)-[r:hearts]->(m:Missile) WHERE u.name = "Trump" RETURN u, type(r), m'
query3 = 'MATCH (u:User)-[r:caresses]->(lover) WHERE u.name = "Putin" RETURN u, type(r), lover'
results1 = db.query(query1, returns = (client.Node, str, client.Node))
results2 = db.query(query2, returns = (client.Node, str, client.Node))
results3 = db.query(query3, returns = (client.Node, str, client.Node))

for r in results1:
    print('(%s)-[%s]->(%s)' % (r[0]["name"], r[1], r[2]["name"]))

for r in results2:
    print('(%s)-[%s]->(%s)' % (r[0]["name"], r[1], r[2]["name"]))

for r in results3:
    print('(%s)-[%s]->(%s)' % (r[0]["name"], r[1], r[2]["name"]))