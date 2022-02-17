using UnityEngine;
using System.Generic;
using System.Generic.Collection;


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
    
    
    IEnumerator STIMUILATE()
    {
    	
        
		
        _CONSTRUCTOR_._INITIALIZE();
        
        
        
        while(true)
        {
            _CONSTRUCTOR._Propagate_(new bool[4] { true , false , false , false } );
            
            yield return new WaitForSeconds(5f);
        }
        	
    	
        yield return null;
    }
    
    
    
    
    
    public static class _CONSTRUCTOR_
    {
        
        
        
        /*
        0, 1, 2, 3, 4.... silicon or Isilicon
        0, 1         .... metal
        0, 1         .... via
        
        */
        
        
        public static int[,][] _Rs_Ys_IRs_IYs__Metal__Via___2D;
        
        
        
        
        // Relation
        // Rs...IRs , Ys...IYs , Rs...IYs...Rs , Ys...IRs...Ys , Rs....M , Ys...M
        // IRs....Rs , IYs....Ys , IRs....M , IYs....M
        // M....Rs , M....Ys , M....IRs , M....IYs
        // 
        //
        public static int[][] Rs__M;      
        public static int[][] Ys__M;       

        public static int[][] Rs__IYs;
        public static int[][] Rs__IYs__Rs;

        public static int[][] Ys__IRs;
        public static int[][] Ys__IRs__Ys; 

        
        public static int[][] IRs__M;
        public static int[][] IYs__M;       

        
        public static int[][] M__Rs;
        public static int[][] M__Ys;

        public static int[][] M__IRs;
        public static int[][] M__IYs;

        
        
        
        
        
        
        public static bool[] Rs_switch;
        public static bool[] Rs_switch;
        public static bool[] IYs_switch;
        public static bool[] IYs_switch;
        public static bool[] M_switch;
        
        
        
        
        
        
        
        
        public static void _INITIALIZE()
        {
            List<int[]> R_Silicon_region,
            			Y_Silicon_region,
            			IR_Silicon_region,
            			IY_Silicon_region,
            			Metal_region;
            
            
            /*

            FLood_Fill

            _Rs_Ys_IRs_IYs__Metal__Via___2D to....
            List<int[]> R_Silicon_region,
                        Y_Silicon_region,
                        IR_Silicon_region,
                        IY_Silicon_region,
                        Metal_region;

            */






            /*

            Relation


            Rs__M;      
            Ys__M;      
            Rs__IYs;
            Rs__IYs__Rs;
            Ys__IRs;
            Ys__IRs__Ys;

            IRs__M;
            IYs__M;  

            M__Rs;
            M__Ys;
            M__IRs;
            M__IYs;

            */




            /*
                RESET_all_switch_to_false
            	
            */
        
        
        }
        
        
        public static void _Propagate_( bool[] curr__M_switch )
        {
   
            /*
            bool[] prev__IRs_switch =  IRs_switch;
            bool[] prev__IYs_switch =  IYs_switch;
            							
            Reset Rs , Ys , IRs , IYs ...__switch ...false
            M__switch .... curr__M_switch
            
            */
    
    
    
    
            /*
            	
            loop(30)
                loop(all_silicon)
                    loop(all_its_relation__metal)
                        if(!on).... set_it_on
                    loop(all_its_relation__Isilicon)
                        loop(all_its_relation__Isilicon__silicon)
                            if(depending_on_Isilicon_type && !on ).... set_it_on
    
    
                loop(all_Isilicon)
                    loop(all_its_relation__metal)
                        if(!on).... set_it_on
    
    
                loop(all_Metal)
                    loop(all_its_relation__silicon)
                        if(!on).... set_it_on
                    loop(all_its_relation__Isilicon)
                        if(!on).... set_it_on       
            */
            
            
            
            
        }
        
        
        
    }
    //...................................................//
    
    

}

