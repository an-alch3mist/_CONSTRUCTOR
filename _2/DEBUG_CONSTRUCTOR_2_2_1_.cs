using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class DEBUG_CONSTRUCTOR_2 : MonoBehaviour
{
    // INITIALIZE
    // FLOOD_FILL
    //.... _switch
    //.... RELATION 
    
    // PROPAGATE
    
    
    
    //// FLOOD_FILL ////
    public static List<List<int[]>> FLOOD_FILL(int[,] BOARD_2D_)
    {
        int x_L = BOARD_2D_.GetLength(0),
        	y_L = BOARD_2D_.GetLength(1);
        
        
        bool[,] _evaluated_2D_ = new bool[x_L , y_L];
        
        for(int y = 0 ;y < y_L ; y += 1)
        {
            for(int x = 0; x < x_L ; x += 1)
            {
                if(BOARD_2D_[x,y] == -1 ) { _evaluated_2D_[x , y] = true;  }
                else                      { _evaluated_2D_[x , y] = false; }
            }
        }
        //
        
        
        
		  
        List<List<int[]>> _region_1D_ = new List<List<int[]>>();
		
        //...region_1D....//
		for(int y0 = 0 ; y0 < y_L ; y0 += 1)
        {
            for(int x0 = 0 ; x0 < x_L ; x0 += 1)
            {
                if(_evaluated_2D_[x0 , y0]) 
                { continue; }
                
                //.......region......//
				List<int[]> _region_ = new List<int[]>();
                _region_.Add(new int[2] { x0 , y0 }; )
                _evaluated_2D_[x0 , y0] = true;
                
                
                whie(true)
                {
                    bool one_of_block_got_evaluated = false;
                    
                    
                    for(int i0 = 0 ; i0 < _region_.Count ; i0 += 1)
                    {
                        int[][] _dirs = new int[4][]
                        {
                            new int[2] { +1 , +0 },
                            new int[2] { +0 , +1 },
                            new int[2] { -1 , +0 },
                            new int[2] { +0 , -1 },
                        };
                        
                        
                        //....._dirs......//
                        for(int i1 = 0 ; i1 < _dirs.Length ; i1 += 1)
                        {
                            int X = _region_[i0][0] + _dirs[i1][0],
                            	Y = _region_[i0][1] + _dirs[i1][1];
                            
                            if(X >= 0 && X < x_L &&
							   Y >= 0 && Y < y_L )
                            {
                            	if(_evaluated_2D_[X , Y])
                            	{ continue; }
                                //
								
								_region_.Add( new int[2] { X , Y } );
                            	_evaluated_2D_[X , Y] = true;
                                
                                one_of_block_got_evaluated = true;
                            }
                                
                        }
                        //....._dirs......//

                    }
                    
                    
                    
                    if(!one_of_block_got_evaluated)
                    { break; }
                }
                
                
                _region_1D_.Add(_region_);
                
                //.......region......//
                
                
                
            }
        }
        //...region_1D....//
        return _region_1D_;
    }
    //
    //// FLOOD_FILL ////

    
    //// SPLIT ////
    /*
    0 Rs,
    1 Ys,
    2 IRs,
    3 IYs,

	4 M,

    */
    
    static List<List<int[]>> region_1D_Rs_;
    static List<List<int[]>> region_1D_Ys_;
    static List<List<int[]>> region_1D_IRs_;
    static List<List<int[]>> region_1D_IYs_;
    static List<List<int[]>> region_1D_M_;
    
    
    
    public static void region_1D_1D(int[,] BOARD_2D_,  List<List<int[]>> region_1D_silicon)
    {     
        region_1D_Rs_  = new List<List<int[]>>();	
		region_1D_Ys_  = new List<List<int[]>>();
		region_1D_IRs_ = new List<List<int[]>>();
		region_1D_IYs_ = new List<List<int[]>>();
        
        for(int i0 = 0 ; i0 < region_1D_silicon.Count ; i0 += 1)
        {
            	 if(BOARD_2D_[region_1D_silicon[i0][0][0] , region_1D_silicon[i0][0][1]] == 0) { region_1D_Rs_ .Add(region_1D_silicon[i0]);}
            else if(BOARD_2D_[region_1D_silicon[i0][0][0] , region_1D_silicon[i0][0][1]] == 1) { region_1D_Ys_ .Add(region_1D_silicon[i0]);}
            else if(BOARD_2D_[region_1D_silicon[i0][0][0] , region_1D_silicon[i0][0][1]] == 2) { region_1D_IRs_.Add(region_1D_silicon[i0]);}
            else if(BOARD_2D_[region_1D_silicon[i0][0][0] , region_1D_silicon[i0][0][1]] == 3) { region_1D_IYs_.Add(region_1D_silicon[i0]);}      
        }
        
        
        
    }
    //// SPLIT ////
  
    
    
    
    //// RELATION ////
    public static int region_index_at_X_Y_(List<List<int[]>> _region_1D_ , int X , int Y)
    {

        for(int i0 = 0 ; i0 < _region_1D_.Count ; i0 += 1)
        {
			for(int i1 = 0 ; i1 < _region_1D_[i0].Count  ; i1 += 1)
            {
                //
        		if(_region_1D_[i0][i1][0] == X && _region_1D_[i0][i1][1] == Y)
                {
             		 return i0;
                }
				//
            }
        }
        
        return -10;
        
    }
    
    
    

    //// RELATION ////
    public static int[][] relation_of_type_A_region__to__type_B_region_neighbour_(List<List<int[]>> _region_1D_A_ , List<List<int[]>> _region_1D_B_)
    {
        
        List<List<int>> TA_TB_1D_1D = new List<List<int>>();
        
        
        int[][] _dirs = new int[4][]
        {
            new int[2] { +1 , +0 },
            new int[2] { +0 , +1 },
            new int[2] { -1 , +0 },
            new int[2] { +0 , -1 },
        };
        
        
        
		for(int i0 = 0 ; i0 < _region_1D_A_.Count ; i0 += 1)
        {
            
            List<int> TA_TB_1D = new List<int>();
            
        	for(int i1 = 0 ; i1 < _region_1D_A_[i0].Count ; i1 += 1)
            {
                for(int i2 = 0 ; i2 < _dirs.length ; i2 += 1)
                {
                    
                    int X = _region_1D_A_[i0][i1][0] + _dirs[i2][0],
                    	Y = _region_1D_A_[i0][i1][1] + _dirs[i2][1];
                    

					int _region_index_at_X_Y_ = region_index_at_X_Y_(_region_1D_B_ , X , Y);
					if(_region_index_at_X_Y_ !=  -10)
					{
					    if(!TA_TB_1D.Contains(_region_index_at_X_Y_))
					    { TA_TB_1D.Add(_region_index_at_X_Y_); }
					}

                    
                    
                    
                }
            }
  			
  			
  			TA_TB_1D_1D.Add(TA_TB_1D);
        }
        
        
               
        /* */
        int[][] _TA_TB_1D_1D_ = new int[TA_TB_1D_1D.Count][];
        
        for(int i0 = 0 ; i0 < TA_TB_1D_1D.Count ;i0 += 1)
        {
            _TA_TB_1D_1D_[i0] = new int[TA_TB_1D_1D[i0].Count];
            for(int i1 = 0; i1 < TA_TB_1D_1D[i0].Count ; i1 += 1)
            {
            	_TA_TB_1D_1D_[i0][i1] = TA_TB_1D_1D_[i0][i1];
            }
            //
        }
        
        return _TA_TB_1D_1D_;
    }
    

    
    
    public static int[][] relation_of_type_A_region__to__type_B_region_via_( List<List<int[]>> _region_1D_A_ , List<List<int[]>> _region_1D_B_ , int[,] BOARD_2D_via_)
    {
        
        List<List<int>> TA_TB_1D_1D = new List<List<int>>();
        
        
        
		for(int i0 = 0 ; i0 < _region_1D_A_.Count ; i0 += 1)
        {
            
            List<int> TA_TB_1D = new List<int>();
            
        	for(int i1 = 0 ; i1 < _region_1D_A_[i0].Count ; i1 += 1)
            {
				int X = _region_1D_[i0][i1][0],
                 	Y = _region_1D_[i0][i1][1];
                
                
                if(BOARD_2D_via_[X , Y] == 0)
                {
                    
                    int _region_index_at_X_Y_ = region_index_at_X_Y_(_region_1D_B_ , X , Y);
                    if(_region_index_at_X_Y_ !=  -10)
                    {

                        //
                        if(!TA_TB_1D.Contains(_region_index_at_X_Y_))
                        { TA_TB_1D.Add(_region_index_at_X_Y_); }
                    }
                }
				


            }
  			//

  			TA_TB_1D_1D.Add(TA_TB_1D);
        }
        
        
               
        /* */
        int[][] _TA_TB_1D_1D_ = new int[TA_TB_1D_1D.Count][];
        
        for(int i0 = 0 ; i0 < TA_TB_1D_1D.Count ;i0 += 1)
        {
            _TA_TB_1D_1D_[i0] = new int[TA_TB_1D_1D[i0].Count];
            for(int i1 = 0; i1 < TA_TB_1D_1D[i0].Count ; i1 += 1)
            {
            	_TA_TB_1D_1D_[i0][i1] = TA_TB_1D_1D_[i0][i1];
            }
            //
        }
        
        return _TA_TB_1D_1D_;
    }
    
    
    
    /*	*/
    public static int[][][]  _relate_silicon__Isilicon(int[][] silicon , int[][] Isilicon)
    {
        
    }
    
    //// RELATION ////
    
    
    
    
    
    
    
    
    
}
