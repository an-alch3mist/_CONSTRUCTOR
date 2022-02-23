//
using UnityEngine;
using System.Collection;
using System.Collection.Generic;



public class DEBUG_CONSTRUCTOR_2 : MonoBehaviour
{
    private void Update()
    {
    	if(Input.GetMouseButtonDown(1)) 
        {
            StopAllCoroutines();
            StartCoroutine(STIMULATE());
            
            //
        }
        
    }
    
    
    
    
    IEnumerator STIMULATE()
    {
    	
        
        
        _CONSTRUCTOR_.INITIALIZE();
        
        while(true)
        {
        	_CONSTRUCTOR._PROPAGATE();
            
            yield return new WaitForSeconds(2f);
        }
        
        
        yield return null;
    }
    
    
    
    
    
    
    
    public static class _CONSTRUCTOR_
    {
        /* Relation */
        
        int[][] Rs_IYs;
        int[][] Ys_IRs;
        int[][][] Rs_IYs_Rs;
        int[][][] Ys_IRs_Ys;
        
        int[][] Rs_M;
        int[][] Ys_M;
    
        
        
        int[][] IRs_M;
        int[][] IYs_M;
        
        
        
        int[][] M_Rs;
        int[][] M_Ys;
        
        int[][] M_IRs;
        int[][] M_IYs;
        
        
        
        
        
        
        
        /* switch  */
        
        bool[] Rs;
        bool[] Ys;
        bool[] IRs;
        bool[] IYs;
        bool[] M;
        
        
        
        
        
        /* BOARD */
        int[,][] Rs_Ys_IRs_IYs__M__via_;
        
        
        
        public static void _INITIALIZE()
        {
            
            
            List< List<int[]> > Rs_region_1D;
            List< List<int[]> > Ys_region_1D;
            List< List<int[]> > IRs_region_1D;
            List< List<int[]> > IYs_region_1D;
 
            List<int[]> via_1D;
            
            
            
            
            
            /*
            Rs_Ys_IRs_IYs__M__via_
            
            Rs__or__Ys__or__IRs__or__IYs...... -1, 0, 1, 2, 3,
            M                            ..... -1, 0
            via                          ..... -1, 0
            
            
            List< List<int> > S_region_1D;
            List< List<int> > M_region_1D;
            
            
            S_region_1D ....  Rs_region_1D , Ys_region_1D , IRs_region_1D ,IYs_region_1D
            M_region_1D
            via_1D
            
            */
            
            
            /*


            Rs_region_1D - IYs_region_1D  ... Rs_IYS
            Ys_region_1D - IRs_region_1D  ... Ys_IRs


            IYs_region_1D - Rs_region_1D ... int[][] IYs_Rs
            IRs_region_1D - Ys_region_1D ... int[][] IRs_Ys
            

            Rs_IYs ... IYs_Rs ... Rs_IYs_Rs
            Ys_IRs ... IRs_Ys ... Ys_IRs_Ys
            
            
            
            Rs_region_1D - M_region_1D  ... Rs_M
            Ys_region_1D - M_region_1D  ... Ys_M
            IRs_region_1D - M_region_1D ... IRs_M
            IYs_region_1D - M_region_1D ... IYs_M
            
            M_region_1D - Rs_region_1D  ... M_Rs
            M_region_1D - Ys_region_1D  ... M_Ys
            M_region_1D - IRs_region_1D ... M_IRs
            M_region_1D - IYs_region_1D ... M_IYs
            

            
            
            */
            
            
            /*
            
            Rs_switch
            Ys_switch
            IRs_switch
            IYs_switch
            M_switch
            
            */
            
        }
        
        
        
        public static void _PRPAGATE(bool[] curr_M_switch)
        {
            /*
            
            bool[] prev_IRs_switch = _copy(IRs_switch)
            bool[] prev_IYs_switch = _copy(IYs_switch)
            
            M_switch = curr_M_switch
            
            */
            
            
            
            
            /*
            RESET
            
            Rs_switch
            Ys_switch
            IRs_switch
            IYs_switch
            M_switch
            
            */
            
            
            
            
            
            /*
            loop 30
        	    
                loop ..Rs
                    loop ...IYs
                        loop ..Rs
                            if(IYs on) if(!on) switch it on

                loop ..Rs
                    loop ...M
                        if(!on) switch it on



                loop ..IRs
                    loop ...M
                        if(!on) switch it on




                loop ..M
                    loop ...R
                        if(!on) switch it on

                loop ..M
                    loop ...IR
                        if(!on) switch it on
            */
        
        }
        
    
    
    
    
    
    
    	//TOOL
    	static List<List<int[]>> FLOOD_FILL(int[,] BOARD)
        {
            int x_L = BOARD.GetLength(0),
                y_L = BOARD.GetLength(1);
            
            
        	bool[,] _evaluated_2D = new bool[x_L , y_L];
            
            for(int y =0 ; y < y_L ; y += 1)
            {
                for(int x = 0 ;  x < x_L ; x += 1)
                {
                    _evaluated_2D[x , y] = false;
                    if(BOARD[x , y] == -1) { _evaluated_2D[x , y] = true; }
                }
            }
            
            
            
            
            
            List<List<int[]>> region_1D = new List<List<int[]>>();
            
            
            for(int y0 = 0 ; y0 < y_L ; y += 1)
            {
                for(int x0 = 0 ; x0 < x_L ; x += 1)
                {
                    if(_evaluated[x,y]) { continue; }
                    
                    
                    
                    
                    List<int[]> _region = new List<int[]>();
                    region.Add(new int[2] { x0 , y0 } );
                    _evaluated_2D[x, y] = true;
                    
                    while(true)
                    {
                        bool one_of_it_got_evaluated = false;
                        
                    	for(int i0 = 0 ;  i0 < _region.Count ;  i0 += 1)
                        {
                            int[][] _dirs = new int[4][]
                            {
                                new int[2] { +1 , +0 },
                                new int[2] { +0 , +1 },
                                new int[2] { -1 , +0 },
                                new int[2] { +0 , -1 },
                            };
                            
                            for(int i1 = 0 ; i1 < _dirs.length ; i1 += 1)
                            {
                                
                                
                                int X = _region[i0][0] + _dirs[i1][0],
                                    Y = _region[i0][1] + _dirs[i1][1];
                            	if( X >= 0 && X < x_l && 
                                    Y >= 0 && Y < y_l )
                                {
                                	if(!_evaluated_2D[X , Y])
                                    {
                                        //
                                        if( BOARD[X,Y] == BOARD[_region[i0][0] , _region[i0][1]] )
                                        {
                                            _region.Add(new int[2] { X , Y } );
                                            _evaluated_2D[X , Y] = true;
                                            
                                            one_of_it_got_evaluated = true;
                                        }
                                        //
                                    }
                                }
                                //

                                
                            }
                            //

                        }
                        
                        
                        
                        if(!one_of_it_got_evaluated) { break; }
                    }
                    
                    
                    region_1D.Add(region);
                      
                } 
                
            }
            
            
            
            
            
            return region_1D;
        }
        //....................//
        
        
        
        
        
        static int region_index(List<List<int[]>> region_1D , int[] _pos)
        {
            
            
            for(int i0 = 0; i0 < region_1D.Count ; i0 += 1)
            {
                for(int i1 = 0 ;i1 < region_1D[i0].Count ; i1 += 1)
                {
                    if( region_1D[i0][i1][0] == _pos[0] && region_1D[i0][i1][1] == _pos[1] )
                    {
                        return i0;
                    }
                }
            }
            
            return -10;
            
        }
        //
        
        
        
    }
    
    
    

    
    
	
}


















