using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class DEBUG_CONSTRUCTOR_2 : MonoBehaviour
{
    
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
        	StopAllCoroutines();
            StartCoroutine(STIMULATE());
        }
        //
    }
    
    IEnumerator STIMULATE()
    {
        #region frame_rate
        
        QualitySettings.vSyncCount = 2;
        yield return null;
        yield return null;
        
        #endregion
        
        
        int[,] BOARD_2D_ = new int[10 , 10];
        int[,] BOARD_2D_M_     = new int[ BOARD_2D_.GetLength(0) , BOARD_2D_.GetLength(1) ];
        int[,] BOARD_2D_M_via_ = new int[ BOARD_2D_.GetLength(0) , BOARD_2D_.GetLength(1) ];
        
        
        
        for(int y = 0 ; y < BOARD_2D_.GetLength(1); y += 1 )
        {
            for(int x = 0 ; x < BOARD_2D_.GetLemgth(0); x += 1)
            {
                BOARD_2D_[x ,  y] = -1;
                
                BOARD_2D_M_[x ,  y] = -1;
                BOARD_2D_M_via_[x , y] = -1;
            }
        }
        //
        
        
        
        while( true )
        {
            
            
            ////// INPUT //////
            if(Input.GetMouseButton(0))
            {
                int X = Mathf.RoundToInt(pos2D.x),
                 	Y = Mathf.RoundToInt(pos2D.y);
                
                if(X >= 0 && X < BOARD_2D_.GetLength(0) &&
                   Y >= 0 && Y < BOARD_2D_.GetLength(1))
                {
                	BOARD[X , Y] = -1;
                    
						 if(Input.GetKey(KeyCode.Alpha1)) { BOARD_2D_[X , Y] = +0; }
                    else if(Input.GetKey(KeyCode.Alpha2)) { BOARD_2D_[X , Y] = +1; }  
                    else if(Input.GetKey(KeyCode.Alpha3)) { BOARD_2D_[X , Y] = +2; }  
                    else if(Input.GetKey(KeyCode.Alpha4)) { BOARD_2D_[X , Y] = +3; }  
                    
                    
                    
                    else if(Input.GetKey(KeyCode.Alpha5)) { BOARD_2D_M_[X , Y] = 0; }
                    else if(Input.GetKey(KeyCode.Alpha6)) 
                    { 
                        if( BOARD_2D_[X , Y] != -1 && BOARD_2D_M_[X , Y] == +0 )
                        {
                            BOARD_2D_M_via_[X , Y] = 0 ;
                        }
                        //
                    }
                    
                    
                    else if( Input.GetKey(KeyCode.Space )) 
                    { 
                        BOARD_2D_[X , Y]       = -1; 
                        BOARD_2D_M_[X , Y]     = -1;
                        BOARD_2D_M_via_[X , Y] = -1;
                    
                    }  
                    
                  
                }
                
                         
            }
            ////// INPUT //////
            
            
            
            
            
            ////// DRAW //////
            DRAW.INITIALIZE();
            DRAW.dt = Time.DeltaTime;
            for(int y = 0 ; y < BOARD_2D_.GetLength(1) ; y += 1)
            {
                for(int x = 0 ; x < BOARD_2D_.GetLength(0) ; x += 1)
                {
                    	 if(_BOARD_2D_[x,y] == -1) { DRAW.col_1D[0]; }
                    else if(_BOARD_2D_[x,y] == +0) { DRAW.col_1D[1]; }
                    else if(_BOARD_2D_[x,y] == +1) { DRAW.col_1D[2]; }
                    else if(_BOARD_2D_[x,y] == +2) { DRAW.col_1D[1]; }
                    else if(_BOARD_2D_[x,y] == +3) { DRAW.col_1D[2]; }
                    
                    
                    
                    
                    
                    //....QUAD ....//
					DRAW.QUAD( new Vector3(x , y, 0f) , 0.96f , 1f/20 ,
                    
                    	_corner_highlight : (BOARAD_2D_[x , y] == 2 || BOARAD_2D_[x , y] == 3),
                              
                    	(x + 1 < BOARD_2D_.GetLength(0) - 1)? ( BOARD_2D_[x + 1 , y + 0] == BOARD_2D_[x , y] ) : false,
                    	(y + 1 < BOARD_2D_.GetLength(1) - 1)? ( BOARD_2D_[x + 0 , y + 1] == BOARD_2D_[x , y] ) : false,
                    	(x - 1 >= 0						   )? ( BOARD_2D_[x - 1 , y + 0] == BOARD_2D_[x , y] ) : false,
                    	(y - 1 >= 0						   )? ( BOARD_2D_[x + 0 , y - 1] == BOARD_2D_[x , y] ) : false,
                    	
					);
                    //....QUAD ....//
                    
                    
                }
            }
            ////// DRAW //////
            
            
            if(Input.GetMouseButtonDown(2))
            {
                break;
            }
            
            
            yield return null;
        }
        
        
        
        
        
        
        CONTRUCTOR_.INITIALIZE( CONTRUCTOR_TOOL_.FLOOD_Fill(BOARD_2D_) );
        CONTRUCTOR_.INITIALIZE( CONTRUCTOR_TOOL_.FLOOD_Fill(BOARD_2D_M_) );
        
        
        
        
        yield return null;
        
    }
    
    
    
    
    public Camera cam;
    public Vector2 pos2D 
    { get { // } }
    
        
        
        
	public static class _CONSTRUCTOR
	{
        
        int[,] BOARD_2D_;
        int[,] BOARD_2D_M_;
        int[,] BOARD_2D_M_via_;
        
        public static void INITIALIZE()
        {
            //
        }
        
        
		static bool[] Rs_switch_;
		static bool[] Ys_switch_;
		static bool[] IRs_switch_;
		static bool[] IYs_switch_;
		static bool[] M_switch_;
        
        
        
        static List<List<int[]>> region_1D_Rs_;
        static List<List<int[]>> region_1D_Ys_;
        static List<List<int[]>> region_1D_IRs_;
        static List<List<int[]>> region_1D_IYs_;
        static List<List<int[]>> region_1D_M_;
        
        
        
 
		static int[][] Rs_IYs;
		static int[][] Ys_IRs;
        static int[][] IRs_Ys;
		static int[][] IYs_Rs;
        
		static int[][][] Rs_IYs_Rs;
		static int[][][] Ys_IRs_Ys;
 
        
		static int[][] Rs_M;
		static int[][] Ys_M;
  
		static int[][] IRs_M;
		static int[][] IYs_M;
 
		static int[][] M_Rs;
		static int[][] M_Ys;
		static int[][] M_IRs;
		static int[][] M_IYs;
        
        
        
        public static void INITIALIZE_RELATION()
        {
       		region_1D_1D_(FLOOD_FILL(BOARD_2D_));
            region_1D_M_ =  FLOOD_FILL(BOARD_2D_M_);
            
            
            
            Rs_switch_  = new bool[region_1D_Rs_.Count];
			Ys_switch_  = new bool[region_1D_Ys_.Count];
			IRs_switch_ = new bool[region_1D_IRs_.Count];
			IYs_switch_ = new bool[region_1D_IYs_.Count];
			M_switch_   = new bool[region_1D_M_.Count];
            
            
            
            Rs_IYs = relation_of_type_A_region__to__type_B_region_neighbour_(region_1D_Rs_  , region_1D_IYs_);
            Ys_IRs = relation_of_type_A_region__to__type_B_region_neighbour_(region_1D_Ys_  , region_1D_IRs_);
            IYs_Rs = relation_of_type_A_region__to__type_B_region_neighbour_(region_1D_IYs_ , region_1D_Rs_ );
            IRs_Ys = relation_of_type_A_region__to__type_B_region_neighbour_(region_1D_IRs_ , region_1D_Ys_ );
            
            
            
            Rs_IYs_Rs = _relate_silicon__Isilicon( Rs_IYs , IYs_Rs );
            Ys_IRs_Ys = _relate_silicon__Isilicon( Ys_IRs , IRs_Ys );
            
            
            
            
            
            Rs_M  = relation_of_type_A_region__to__type_B_region_via_(region_1D_Rs_   , region_1D_M_ , BOARD_2D_M_via_);
            Ys_M  = relation_of_type_A_region__to__type_B_region_via_(region_1D_Ys_   , region_1D_M_ , BOARD_2D_M_via_);
            IRs_M = relation_of_type_A_region__to__type_B_region_via_(region_1D_IRs_  , region_1D_M_ , BOARD_2D_M_via_);
            IYs_M = relation_of_type_A_region__to__type_B_region_via_(region_1D_IYs_  , region_1D_M_ , BOARD_2D_M_via_);
            
            M_Rs   = relation_of_type_A_region__to__type_B_region_via_( region_1D_M_ , region_1D_Rs_   , BOARD_2D_M_via_);
            M_Ys   = relation_of_type_A_region__to__type_B_region_via_( region_1D_M_ , region_1D_Ys_   , BOARD_2D_M_via_);
            M_IRs = relation_of_type_A_region__to__type_B_region_via_( region_1D_M_ , region_1D_IRs_  , BOARD_2D_M_via_);
            M_IYs = relation_of_type_A_region__to__type_B_region_via_( region_1D_M_ , region_1D_IYs_  , BOARD_2D_M_via_);
            
        }
        
        
        
        
        //.... _PROPAGATE ....//
        
        public static void _PROPAGATE(bool[] curr_M_switch_)
        {
            //.... curr_M_switch , prev_IRs__IYs_switch ....//
            for(int i = 0 ; i < M_switch_.Length ; i += 1)
            {
            	M_switch_[i] = curr_M_switch_[i];
            }
            //
            
            bool[] prev_IRs_switch_ = new bool[IRs_switch.Length];
            bool[] prev_IYs_switch_ = new bool[IYs_switch.Length];
            
            
            
            
            //.... iter ....//
            for(int iter = 0 ; iter < 30 ; iter += 1)
            {
                
             
             //.... Rs ....//
             for(int i0 = 0 ; i0 < Rs_switch_.Length ;i0 += 1)
             { 
                 if(Rs_switch_[i0])
                 {
                     for(int i1 = 0 ;i1 < Rs_IYs.Length ; i1 += 1)
                     {
                         for(int i2 = 0 ;i2 < Rs_IYs_Rs[i0][i1].Length ; i2 += 1)
                         {
                             if(prev_IYs_switch_[Rs_IYs[i0][i1]]) { Rs_switch_[ Rs_IYs_Rs[i0][i1][i2] ] = true; } 
                         }
                     }


                     for(int i1 = 0 ;i1 < Rs_M.Length ; i1 += 1) { M_switch_[ Rs_M[i0][i1] ] = true; }


                 }
             }
             //.... Rs ....//
             
             
             //.... Ys ....//
             for(int i0 = 0 ; i0 < Ys_switch_.Length ;i0 += 1)
             { 
                 if(Ys_switch_[i0])
                 {
                     for(int i1 = 0 ;i1 < Ys_IRs.Length ; i1 += 1)
                     {
                         for(int i2 = 0 ;i2 < Ys_IRs_Ys[i0][i1].Length ; i2 += 1)
                         {
                             if(!prev_IRs_switch_[Ys_IRs[i0][i1]]) { Ys_switch_[ Ys_IRs_Ys[i0][i1][i2] ] = true;  }

                         }
                     }


                     for(int i1 = 0 ;i1 < Ys_M.Length ; i1 += 1) { M_switch_[ Ys_M[i0][i1] ] = true; }


                 }
             }
             //.... Ys ....//
             
             
             
             // .... IRs .... //
            for(int i0 = 0 ; i0 < IRs_switch_.Length ;i0 += 1)
            { 

               	if(IRs_switch_[i0]) {  for(int i1 = 0 ;i1 < IRs_M.Length ; i1 += 1)  { M_switch_ [ IRs_M[i0][i1] ] = true; }  }
              
            }
            // .... IRs .... //

             
             // .... IYs .... //
            for(int i0 = 0 ; i0 < IYs_switch_.Length ;i0 += 1)
            { 

               	if(IYs_switch_[i0]) {  for(int i1 = 0 ;i1 < IYs_M.Length ; i1 += 1)  { M_switch_ [ IYs_M[i0][i1] ] = true; }  }
              
            }
            // .... IYs .... //
             
             
             
            
            // .... M .... //
            for(int i0 = 0 ; i0 < M_switch_.Length ;i0 += 1)
            { 

               	if(M_switch_[i0])
                {
                    for(int i1 = 0 ;i1 < M_Rs.Length ; i1 += 1)  { Rs_switch_ [ M_Rs[i0][i1] ] = true; }
                    for(int i1 = 0 ;i1 < M_Ys.Length ; i1 += 1)  { Ys_switch_ [ M_Ys[i0][i1] ] = true; }
                    for(int i1 = 0 ;i1 < M_IRs.Length ; i1 += 1) { IRs_switch_[ M_IRs[i0][i1] ] = true; }
                    for(int i1 = 0 ;i1 < M_IYs.Length ; i1 += 1) { IYs_switch_[ M_IYs[i0][i1] ] = true; }

                    
                }
              
            }
            // .... M .... //
            
            
            
            
            
            
            }
            //.... iter ....//
            
            
        }
        //.... _PROPAGATE ....//

        
    }        
        
        
        
        
    
    /* DRAW */
    public static class DRAW
    {
        public static Color[] col_1D;
        
        public static void INITIALIZE()
        {
            col_1D = new Color[3]
            {
                Color.HSVToRGB( 0.00f , 0.00f , 0.30f ),
                Color.HSVToRGB( 0.00f , 0.30f , 0.80f ),
                Color.HSVToRGB( 0.15f , 0.25f , 0.65f ), 
            };
            //
        }
        
        
        
        public static void QUAD( Vector3 o , float s  , float e , bool _corner_highlight 
                               , params bool[] neighbour_state_1D ) 
        { // }
    }
        
        
    
    
}
