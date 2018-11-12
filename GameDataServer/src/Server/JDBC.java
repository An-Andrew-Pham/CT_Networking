package Server;
import java.sql.Connection; //make sure these packets are java sql ones
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;


public class JDBC {
	public static void main(String [] args) {
		Connection conn = null;
		Statement st = null;
		ResultSet rs = null;
		PreparedStatement ps = null;
		try {
			Class.forName("com.mysql.jdbc.Driver"); //function allows u to create a class at runtime instead of compile
			conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/StudentGrades?user=root&password=root&useSSL=false"); //connect from jdbc -> mysql
			ps = conn.prepareStatement("INSERT INTO Users(username, password_, characterID) VALUES(?,?,?)");
			ps.setString(1, "BOB"); //username
			ps.setString(2, "password"); //password
			ps.setInt(3, 12); //char ID
			ps.execute();
			
		}catch(SQLException sqle) {
			System.out.println("sqle: " + sqle.getMessage());
		}catch(ClassNotFoundException cnfe) {
			System.out.println("cnfe: " + cnfe.getMessage());
		}finally {
			try {
				if(rs != null) {
					rs.close();
				}
				if(st != null) {
					st.close();
				}
				if(conn != null) {
					conn.close();
				}
			}catch(SQLException sqle) {
				System.out.println("sqle c;psomg streams: " + sqle.getMessage());
			}
		}
	}
}
