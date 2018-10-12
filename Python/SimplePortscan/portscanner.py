#!/usr/bin/env python3
import socket
import subprocess
import sys
import threading
from datetime import datetime

#threadLock = threading.Lock()

class scanThread(threading.Thread):
    def __init__(self, threadID, startPort, endPort, remoteServerIP, resultList):
        threading.Thread.__init__(self)
        self.threadID = threadID
        self.startPort = startPort
        self.endPort = endPort
        self.remoteServerIP = remoteServerIP
        self.resultList = resultList
    def run(self):
        #threadLock.acquire()

        resultList = []

        for port in range(int(self.startPort), int(self.endPort) + 1):  
            sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            result = sock.connect_ex((self.remoteServerIP, port))
            if result == 0:
                self.resultList.append("Port {}:     Open".format(port))
            else:
                self.resultList.append("Port {}:     Closed".format(port))
                sock.close()

        #threadLock.release()

def scanner():
    # Clear the screen
    subprocess.call('cls', shell=True)

    # Welcome is printed
    print("-" * 60)
    print("Welcome to the simple portscanner")
    print("-" * 60)

    multiThreaded = input("Do you want to run the scanner in multithread mode? Type y or n: ")
    print("-" * 60)

    # Ask user for host IP
    remoteServer = input("Please, enter a remote host to scan: ")
    remoteServerIP = socket.gethostbyname(remoteServer)

    print("")
    # Ask user for ports to scan
    startPort = input("Specify first port to scan: ")
    endPort = input("Specify last port to scan: ")

    # Tells user that host is being scanned
    print("-" * 60)
    print("Please wait, scanning the remote host", remoteServerIP)

    # Start time of scan
    startTime = datetime.now()

    # Check if multithreaded is chosen or not, run scan accordingly
    if multiThreaded == "y":
        # Initialize lists
        threads = []
        resultList1 = []
        resultList2 = []

        # Cut portrange in 2 halfs and initialize threads
        middlePort = (int(startPort) + int(endPort)) / 2
        thread1 = scanThread(1, int(startPort), middlePort, remoteServerIP, resultList1)
        thread2 = scanThread(2, middlePort +1, int(endPort), remoteServerIP, resultList2)

        # Start threads
        thread1.start()
        thread2.start()

        # Add threads to threads list
        threads.append(thread1)
        threads.append(thread2)

        # Join threads to wait for them to finish
        for thread in threads:
            thread.join()

        # Print the result of the scan
        for result in resultList1:
            print(result)
        for result in resultList2:
            print(result)

    else:
        # Poke ports with user specified portnumbers
        try:
            for port in range(int(startPort), int(endPort) + 1):  
                sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
                result = sock.connect_ex((remoteServerIP, port))
                if result == 0:
                    print("Port {}:     Open".format(port))
                else:
                    print("Port {}:     Closed".format(port))
                sock.close()

        except KeyboardInterrupt:
            print("You pressed Ctrl+C. Terminating.")
            sys.exit()

        except socket.gaierror:
            print('Hostname of remote host could not be resolved. Terminating.')
            sys.exit()

        except socket.error:
            print("No connection to server. Terminating.")
            sys.exit()

    # End time of scan
    endTime = datetime.now()

    # Calculate runtime of scan
    total = endTime - startTime

    # Print info
    print('Scanning Completed in: ', total)
    print("-" * 60)

    # Ask user if another scan is wanted
    scanAgain = input("Would you like to perform another scan? Type y or n: ")

    # React on user choice
    if scanAgain == "n":
        print("")
        print("It's okay, you can go outside and play now!")
        sys.exit()
    else:
        scanner()

scanner()