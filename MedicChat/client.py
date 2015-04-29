'''
Medic Chat Client

Started on 4/18/15

Nishad Trivedi
'''

import socket, sys, select, os
from getpass import getpass


''' Global variables '''
PROMPT = '[Me] -> '
RECV_BUFFER = 4096
COMMANDS = {
	# Chat command : Unix command
	'\play' : 'afplay'
}


def main():
	'''
	Parses command line and calls the initialization of client socket
	'''
	if len(sys.argv) < 3:
		print 'Usage: python client.py <host> <port>'
		sys.exit(0)

	host = sys.argv[1]
	port = int(sys.argv[2])

	initialize(host, port)


def initialize(host, port):
	'''
	Create client socket and establish connection
	'''

	
	''' Create socket '''
	try:
		# Address family IPv4, UDP
		sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
		sock.settimeout(2)
	except socket.error as msg:
		print 'Error: could not create socket. Exiting...\n', msg
		sys.exit(1)

	''' Connect to host '''
	try:
		sock.connect((host, port))
		login(sock, host)
	except socket.error as msg:
		print 'Unable to connect to host. Exiting...\n', msg
		sock.close()
		sys.exit(1)

	while 1:
		sockets = [sys.stdin, sock]
		# Assigns list of sockets ready to be read from or written to
		to_read, to_write, in_error = select.select(sockets , [], [], 0)

		for s in to_read:
			if s == sock:
				# Server is sending message
				message = s.recv(RECV_BUFFER)
				if not message:
					# Broken connection
					print '\nYou are disconnected from the chat room'
					s.close()
					sys.exit(1)
				else:
					sys.stdout.write(message)
					sys.stdout.write(PROMPT); sys.stdout.flush()
			else:
				# Send a message to the server (which will broadcast it to everyone else)
				message = sys.stdin.readline()
				if sanitize_message(message, sock):
					# Returns True if message not a command
					sock.send(message)
					sys.stdout.write(PROMPT); sys.stdout.flush()


def login(sock, host):
	'''
	Supplies username and password to server.
	Logs into account on success.
	Disconnects from room upon failure.
	'''
	# Login to account
	# Server will try to authenticate the user
	sys.stdout.write('Username: '); sys.stdout.flush()
	username = sys.stdin.readline(); sock.send(username)
	password = getpass('Password: ')
	sock.send(password)

	login_reply = sock.recv(512)
	if login_reply != 'Success':
		sys.stderr.write(login_reply)
		sys.stderr.write('You are disconnected from the chat room\n')
		sock.close()
		sys.exit(1)

	print 'Connected to %s. You can start chatting.' % host
	sys.stdout.write(PROMPT); sys.stdout.flush()


def sanitize_message(message, sock):
	'''
	Checks for chat commands in message
	'''
	args = message.split()
	if args[0] in COMMANDS:
		# Message is a chat command
		if args[0] == '\send':
			with open(args[1], 'rb') as f:
				contents = f.read()
				fsize = len(contents)
				while fsize:
					pass

		else:
			pid = os.fork()
			if pid == 0:
				# In child process
				cmd = COMMANDS[args[0]] + ' ' + args[1] + ' &'
				print cmd
				#os.execl(COMMANDS[args[0]], '~/medic-chat/'+args[1])
				os.system(cmd)
				return False
	else:
		# Message not a command
		return True
		





if __name__ == '__main__':
	main()




