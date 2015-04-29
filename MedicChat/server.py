'''
Medic Chat server

Started on 4/18/15

Nishad Trivedi
'''

import socket, sys, select

#HOST = 'localhost'
HOST = 'x-128-101-250-230.uofm-secure.wireless.umn.edu'
PORT = 5555
RECV_BUFFER = 4096 # receive 4096 bytes at a time

# { username : password }
accounts = {
	'nishad':'trivedi',
	'abhi':'vaidya',
	'ishan':'sahu',
	'mohamoud':'egal'
}

sockets = [] # All sockets in connection
usernames = {} # { socket : username }



class ChatRoom:
	'''
	Chat Room
	'''

	def __init__(self, name='room', client=None):
		self.name = name
		self.clients = []
		if client != None:
			add_client(client)

	def set_name(self, name):
		''' Sets room name '''
		self.name = name

	def add_client(self, sock):
		''' Adds user to room '''
		self.clients += [sock]


def initialize():
	'''
	Sets up the server socket and serves client interaction
	'''
	
	global sockets

	''' Create socket '''
	try:
		# Address family IPv4, UDP
		server_sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
		server_sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
	except socket.error as msg:
		print 'Error: could not create socket. Exiting...\n', msg
		sys.exit(1)

	''' Bind socket to host and port '''
	try:
		server_sock.bind((HOST, PORT))
		server_sock.listen(20) # max number of queued connections
		sockets += [server_sock]
		print 'Server listening on port', PORT
	except socket.error as msg:
		print 'Error: could not bind or listen. Exiting...\n', msg
		server_sock.close()
		sys.exit(1)


	while 1:
		# Assigns list of sockets ready to be read from or written to
		to_read, to_write, in_error = select.select(sockets, [], [], 0)
		
		for sock in to_read:
			# New connection. Broadcast new connection message to clients and add new client to sockets list.
			if sock == server_sock:
				'''
				TODO

				Authenticate user
				
				Abstract below to login() function
				'''
				new_client, addr = server_sock.accept()
				login(new_client, server_sock)

			else:
				# Message from client
				try:
					message = sock.recv(RECV_BUFFER)
					if message:
						# Broadcast client's message to everyone else
						broadcast('\r%s: %s' % (usernames[sock], message), sock, server_sock)
					else:
						# Broken connection
						if sock in sockets: 
							sockets.remove(sock)
						broadcast('%s is offline\n' % username[sock], sock, server_sock)
				except:
					broadcast('%s is offline\n' % username[sock], sock, server_sock)
					continue

	server_sock.close()



def broadcast(message, client_sock, server_sock):
	'''
	Broadcasts message to all clients (except @client_sock)
	'''
	for sock in sockets:
		# Only broadcast to other clients
		if (sock != server_sock) and (sock != client_sock):
			try:
				sock.send(message)
			except socket.error as msg:
				# The connection is broken
				print sock, ' lost connection\n%s' % msg
				sock.close()
				if sock in sockets: 
					sockets.remove(client_sock)



def login(client, server):
	'''
	Logs in a user
	'''
	global sockets

	username = client.recv(RECV_BUFFER).strip()
	print 'Received username:', username
	password = client.recv(RECV_BUFFER).strip()

	print 'Received password:', password
	# Add to usernames dictionary if login is successful
	if authenticate(username, password):
		usernames[client] = username
		print 'Added username'

		client.send('Success')
		sockets += [client]
		print '%s %s connected' % (username, client.getpeername())
		broadcast('%s entered the room\n' % username, client, server)
	else:
		client.send('Incorrect username or password\n')
		client.close()



def authenticate(username, password):
	'''
	Authenticates username and password
	'''
	if (username in accounts) and (accounts[username] == password):
		return (username, password)
	else:
		return False 


if __name__ == '__main__':
	initialize()

