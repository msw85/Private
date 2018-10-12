
#!/usr/bin/env python3
import requests
import re
import webbrowser
import sys

globalLinkList = []

def searchSO(searchString):
	file = open('SO_Testfile.txt', 'w', encoding='utf8')

	payload = {'q': searchString}
	r = requests.get('https://www.stackoverflow.com/search', params=payload)

	file.write(r.text)
	file.close()

	SOResult()

def SOResult():
	lines = []
	negativeCount = 0
	positiveCount = 0

	foundLinks = open('SO_foundlinks.txt', 'w', encoding='utf8')

	with open('SO_Testfile.txt', 'rt', encoding='utf8') as file:
		for line in file:
			lines.append(line)

	for line in lines:
		if re.search('href="/questions/[1-9]+', line):
			#print(line)
			positiveCount += 1
			foundLinks.write('Link #' + str(positiveCount) + ': ' + line)
		else:
			negativeCount += 1

	file.close()
	foundLinks.close()

	generateLinks()

def generateLinks():
	lines = []
	# Maybe make function to append to and return a list? Dunno, maybe? Or not.... maybe.
	with open('SO_foundlinks.txt', 'rt', encoding='utf8') as file:
		for line in file:
			lines.append(line)

	links = open('SO_Justlinks.txt', 'w', encoding='utf8')

	for line in lines:
		link = re.search('<a href="(.+?)"', line).group(1)
		fullLink = "https://www.stackoverflow.com" + str(link)
		links.write(fullLink + '\n')
		globalLinkList.append(fullLink)

def presentLinks():
	linkCounter = 0
	with open('SO_Justlinks.txt', 'rt', encoding='utf8') as links:
		for line in links:
			print("Link #" + str(linkCounter) + ": " + line, end='')
			linkCounter += 1
	
def start():
	print("\n~ Stack Overflow search ~")
	tui()

def tui():
		keyword = input("\nKeyword: ")
		print("-" * 60)

		searchSO(keyword)

		print("\nListing search results from 0 - " + str(len(globalLinkList)) + ":\n")

		presentLinks()

		selection = input("\nNumber of link to open: ")
		# Somehow it should be cheked if statement contains letters, if possible
		if int(selection) < len(globalLinkList):
			webbrowser.open_new_tab(globalLinkList[int(selection)])
		else:
			print("\nNot accepted, displaying menu.")
			endMenu()
			

		endMenu()

def endMenu():
		print("-" * 60)
		print("\nPlease choose:")
		print("1 - Open new link")
		print("2 - New search")
		print("3 - Exit")
		userEndMenuChoice = input("Enter number: ")

		if userEndMenuChoice == "1":
			selection = input("\nNumber of link to open: ")
			webbrowser.open_new_tab(globalLinkList[int(selection)])
			endMenu()
		elif userEndMenuChoice == "2":
			del globalLinkList[:]
			tui()
		elif userEndMenuChoice == "3":
			print("\nOkay, bye!")
			sys.exit()
		else:
			print("\nNot accepted, try again.")
			endMenu()

start()