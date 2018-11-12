package Server;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Vector;

public class GameServer {
	
	private Vector<String> playerThreads;
	
	public GameServer(int port)
	{
		ServerSocket ss = null; //Passive class waiting to connect -- after connect u get a socket allowing for communication
		try {
			System.out.println("Trying to bind to port " + port);
			ss = new ServerSocket(port); //nobody else was binded to this port
			//no number error 
			System.out.println("Bound to port " + port);
			playerThreads = new Vector<String>();
			while(true)
			{
				Socket s = ss.accept(); //blocking line code -- always wait for user to connect
				System.out.println("Connection from " + s.getInetAddress());
				//Chatthreat st = new Chatthread(s); //instantiated for every new client 
				//To broadcoast message for all ur clients - u gotta iterate through all
				//ur server threads
				//serverThreads.add(st); 
			}
		}catch(IOException ioe) {
			System.out.println("ioe " + ioe.getMessage() );
		}finally {
			try {
			if (ss != null) {
				ss.close(); //maybe server is already made
			}
			}catch(IOException e)
			{
				System.out.println("ioe" + e.getMessage());
			}
			
		}
	}
	
	public static void main(String [] args)
	{
		new GameServer(6789);
	}
	
	private JDBC parseData;
}
