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
    	
        
        
        
        while(true)
        {
            
        }
        
        
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
        
        
        
    }
	
}




