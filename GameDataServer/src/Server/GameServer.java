package Server;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Vector;
import java.io.PrintWriter;
import com.google.gson.Gson;
import java.io.InputStream;
import java.io.OutputStream;

public class GameServer{
	
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
			
			Socket s = ss.accept(); //blocking line code -- always wait for user to connect
			System.out.println("Connection from " + s.getInetAddress());
			
			InputStream is = s.getInputStream();
	        //OutputStream os = s.getOutputStream();
	        
	        // Receiving
	       /* byte[] lenBytes = new byte[4];
	        is.read(lenBytes, 0, 4);
	        int len = (((lenBytes[3] & 0xff) << 24) | ((lenBytes[2] & 0xff) << 16) |
	                  ((lenBytes[1] & 0xff) << 8) | (lenBytes[0] & 0xff));
	        byte[] receivedBytes = new byte[len];*/
			byte[] receivedBytes = new byte[4];
	        is.read(receivedBytes);
	        String received = new String(receivedBytes, 0, 32);

	        System.out.println("Server received: " + received);
	        
	        // Sending
	       /* String toSend = "Echo: " + received;
	        byte[] toSendBytes = toSend.getBytes();
	        int toSendLen = toSendBytes.length;
	        byte[] toSendLenBytes = new byte[4];
	        toSendLenBytes[0] = (byte)(toSendLen & 0xff);
	        toSendLenBytes[1] = (byte)((toSendLen >> 8) & 0xff);
	        toSendLenBytes[2] = (byte)((toSendLen >> 16) & 0xff);
	        toSendLenBytes[3] = (byte)((toSendLen >> 24) & 0xff);
	        os.write(toSendLenBytes);
	        os.write(toSendBytes);*/

	        s.close();
	        ss.close();
	 
			
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
	
	/*private BufferedReader recv;

	public void run()
	{
	
        try 
        {
            clientSocket = serverSocket.accept();
            System.out.println("Client Connected from " + clientSocket.getInetAddress().getHostAddress() + ":" + clientSocket.getPort());

            recv = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));

            System.out.println("Data Recieved: " + recv.readLine());

            clientSocket.close();
        }
        catch (IOException e) 
        {
            e.printStackTrace();
        }
	    
	}*/
	
	public static void main(String [] args)
	{
		new GameServer(6789);
	}
	
	private JDBC parseData;
}
