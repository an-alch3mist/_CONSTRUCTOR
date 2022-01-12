 
    
    

    /*
    TODO
        silicon - previous_state..... silicon
                  curr_state.... metal
        
        metal - curr_state...... silicon
    */




    #region PROPAGATE
    public PROPAGATE_CURR PROPAGATE(

        
        bool[] metal_state_1D__for_curr_step , 
        bool[] silicon_state_1D__from_prev_step,
        
        
        
        /* silicon - metal */
        
        List<List<int>> metal__silicon_1D__1D ,  
        List<List<int>> silicon__metal_1D__1D ,
        
        
        /* 
        A_silicon - B_silicon - A_silicon
        */
        int[] silicon_type_1D, 
        List<List<int>> __silicon_1D__1D, List<List<List<int>>> __silicon_1D__1D__1D,
        
    )
    {
        
        
        
        bool[] silicon_state_1D__curr_step = new bool[ silicon_state_1D__from_prev_step.Length ];
        for(int i = 0 ; i < silicon_state_1D.Length ; i += 1)
        {
            silicon_state_1D__curr_step[i] = false;
        }
        
        bool[] metal_state_1D__curr_step = new bool[ metal_state_1D__for_curr_step.Length ];
        for(int i = 0 ; i < silicon_state_1D.Length ; i += 1)
        {
            metal_state_1D__curr_step[i] = metal_state_1D__for_curr_step[i];
        }
        
        
        /*
        metal_state_1D__for_curr_step
        silicon_state_1D__from_prev_step
        
        
        metal_state_1D__curr_step
        silicon_state_1D__curr_step
        */
        
        
        
        
        
        
        //
        for(int iter = 0; iter < 10; iter += 1)
        {

            // metal

            for (int i0 = 0; i0 < metal_state_1D__curr_step.Length; i0 += 1)
            {
                if (metal_state_1D__curr_step[i0]) { continue; }
                //

                
                for(int i1 = 0; i1 < metal__silicon_1D__1D[i0].Count; i1 += 1)
                {
                    if(silicon_state_1D__curr_step[metal__silicon_1D__1D[i0][i1]])
                    {
                        metal_state_1D__curr_step[i0] = true;
                        break;
                    }
                }


            }



            // silicon
            for(int i0 = 0; i0 < silicon_state_1D__curr_step.Length; i0 += 1)
            {

                /*
                if (silicon_state_1D[i0]) { continue; }

                */
                //
                if(silicon_type_1D[i0] == 0)
                {

                    int sum = 0;
                    for (int i1 = 0; i1 < __silicon_1D__1D[i0].Count; i1 += 1)
                    {
                        if ( silicon_state_1D__from_prev_step[__silicon_1D__1D[i0][i1]] )
                        {
                            //
                            for (int i2 = 0; i2 < __silicon_1D__1D__1D[i0][i1].Count; i2 += 1)
                            {
                                if(silicon_state_1D__curr_step[ __silicon_1D__1D__1D[i0][i1][i2] ]) 
                                { sum += 1; }
                                
                            }
                            //

                        }
                    }

                    if (sum > 0) { silicon_state_1D__curr_step[i0] = true; }
                    else         { silicon_state_1D__curr_step[i0] = false; }

                }



                else if (silicon_type_1D[i0] == 1)
                {

                    int sum = 0;
                    for (int i1 = 0; i1 < __silicon_1D__1D[i0].Count; i1 += 1)
                    {
                        if ( !silicon_state_1D__from_prev_step[__silicon_1D__1D[i0][i1]] ) 
                        {
                            //
                            for (int i2 = 0; i2 < __silicon_1D__1D__1D[i0][i1].Count; i2 += 1)
                            {
                                if(silicon_state_1D__curr_step[ __silicon_1D__1D__1D[i0][i1][i2] ]) 
                                { sum += 1; }
                                
                            }
                            //

                        }
                    }

                    if (sum > 0) { silicon_state_1D__curr_step[i0] = true; }
                    else         { silicon_state_1D__curr_step[i0] = false; }


                }

                //


                
                
                
                
                //
                for (int i1 = 0; i1 < silicon__metal_1D__1D[i0].Count; i1 += 1)
                {
                    if(metal_state_1D__curr_step[silicon__metal_1D__1D[i0][i1]])
                    { 
                        silicon_state_1D__curr_step[i0] = true;
                        break;
                    }
                }
                //
 
                
            }










        }
        //
        

        return new PROPAGATE_CURR()
        {
            metal_state_1D__curr_state = metal_state_1D__curr_state ,
            silicon_state_1D__curr_state = silicon_state_1D__curr_state
        };
        
    }


    #endregion





	public class PROPAGATE_CURR
  {
      public bool[] silicon_state_1D__curr_state,
      public bool[] metal_state_1D__curr_state
      
      
  }
