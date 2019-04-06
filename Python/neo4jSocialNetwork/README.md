------------ The What --------------  
Simple social network api build with Python3, Flask and Neo4j.

------------- The Why --------------  
To get some experience with Flask and explore graphdatabases via. Neo4j.
NB: Not meant for actual production use. ;)

----- Documentation-ish (WIP) ------
API funtionality:

#USER FUNCTIONALITY#  
/
- Not useful, just made to check if the Flask app was served.

/get/user/all/
- Returns a collection of all the users in the network.

/get/user/<name>
- Returns a user matching the name given.

/get/user/friends/<name>
- Returns a collection of friends of the user.

/get/user/likes/<name>
- Returns a collection of pagelikes of the user.

/get/user/posts/<name>
- Returns a collection of posts by the user.

/get/user/posts/all/
- Get all the posts in the network

/post/user/<name>
- Creates a user by the given name.

/post/user/friendship/<name>/<friend>
- Creates a relationship of type friend between the given 2 users

/post/user/likes/<name>/<page>
- Creates a relationship of type like between the given user and page

/post/user/posts/<name>/<post>
- Creates a post and a relationship of type post between the given user and the post

/delete/user/<name>
- Deletes a user by the given name

/delete/user/friendship/<name>/<friend>
- Deletes a friendship between the 2 users given

/delete/user/likes/<name>/<page>
- Deletes a like between the given user and page

/delete/user/posts/<name>/<post>
- Deletes the given post by the given user

#PAGE FUNTIONALITY#  
/post/page/<name>
- Creates a new page

/delete/page/<name>
- Deletes the given page

#POST FUNTIONALITY#  
None in main script

-------------- TO DO ---------------  
As this is very much a work in progress and a proof of concept,
a lot of things should change.

This list is just some:
- When making requests name strings etc. should be changed for id.
- Error handling
- Checking if an operation is actually successful
- Fixing weird import issues etc. (not requiring total path in path for imports)
- An actual simple webUI/Social network page
- Maybe change datatypes that is exposed by the API

+ many MANY more.
