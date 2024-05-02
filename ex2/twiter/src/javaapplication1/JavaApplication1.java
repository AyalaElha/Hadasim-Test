
package javaapplication1;
import java.util.Scanner;
public class JavaApplication1 {

public static float side(float h, float w){//return  the side of an isosceles triangle by Pythagoras get width and height 
    return (float) Math.sqrt(Math.pow((w/2),2)+Math.pow(h, 2));
}
public static float perimeter(int type,float h, float w){//get type of object 1-triangular,2-rectangle,returns perimeter
    if (type==2)
        return h*2+w*2;
    else    
        return w + 2*side( h,  w);
}
public static float area(int type,float h, float w){//get type of object 1-triangular,2-rectangle,returns area
  //  if (type==2)
        return h*w;
  //  else
  //      return (h*w)/2+(h*w)%2;
}
public static void printLine(int n,float width){//n-numbers of * to print  in line of triangular ,calculate the spaces 
        System.out.println();
        for (int j = 0; j < ((int)width-n)/2; j++) {
            System.out.print(" "); 
        }
         for (int j = 0; j < n; j++) {
            System.out.print("*");
        }       
}
public static void printTriangular(float height,float width){//print triangular by logic idea... 
    int specialLines= (int)(height)-2;
    int blocks=(int)(width-2)/2;//num of same type  lines
    int numOfLinesInBlocks=0;//num of lines in each block
    printLine(1,width);
    for (int i = 1; i <= blocks; i++) {
         if(i==1)
            numOfLinesInBlocks=(specialLines/blocks+specialLines%blocks);//the rest in the first block
         else
             numOfLinesInBlocks=specialLines/blocks;  
         for (int j = 1; j<=numOfLinesInBlocks; j++) {//print each line
            printLine(1+2*i,width);
        }
    }
    printLine((int)width,width);
    System.out.println();
}

public static void main(String[] args) {
       Scanner scan=new Scanner(System.in);
       System.out.println("choosing triangular press 1,  for rectangle press 2,  to exit  press 3 ");
       int x=scan.nextInt();
       float width;
       float height;
       if (x!=1&&x!=2)
       {
           if (x!=3)
                System.out.println("invalid input");
           System.out.println("exiting.....");
           return;
       }
       else 
       while(x==1||x==2)
       {
           System.out.println("insert width and height");
           width=scan.nextFloat();//assuming the width is min 3(for print)
           height=scan.nextFloat();//assuming the height is greater than 1(for print)
           if(x==2){//rectangle
               if(width==height||(Math.abs(width-height))>5)
                    System.out.println("area "+area(2, height,width) );
               else
                    System.out.println("perimeter "+perimeter(2, height,width) );
           }
           else//triangular
           {
               System.out.println("press 1-to print hekef or 2-to print the model");
               x=scan.nextInt();
               if(x==1)
                   System.out.println("perimeter "+perimeter(1, height,width) );
               else 
                       if(width%2==0||width>2*height||width==3&&height>2)//edge case
                           System.out.println("printing is no possible ");
                        else
                           printTriangular(height,width);          
           }       
           System.out.println("choosing triangular press 1,  for rectangle press 2,  to exit  press 3 ");
           x=scan.nextInt();
           if (x!=1&&x!=2)
           {
           if (x!=3)
                System.out.println("invalid input");
           System.out.println("exiting.....");
           return;
           }
       }
       
         
    }
    }
    





