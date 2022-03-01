//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class DEBUG_CONSTRUCTOR_2 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StopAllCoroutines();
            StartCoroutine(STIMULATE());

            //
        }

    }




    IEnumerator STIMULATE()
    {
        #region frame_rate
        QualitySettings.vSyncCount = 4;
        yield return null;
        yield return null;

        #endregion




        /*
        DRAW.col = Color.gray;
        DRAW.dt = 10f;

        DRAW.QUAD(Vector3.zero, 1f, 1f / 20);
        */



        int[,] _BOARD_2D_ = new int[10, 10];
        for (int y = 0; y < _BOARD_2D_.GetLength(1); y += 1)
        {
            for (int x = 0; x < _BOARD_2D_.GetLength(0); x += 1)
            {
                _BOARD_2D_[x, y] = -1;
            }
        }




        #region EDGE_QUAD
        /*
        DRAW.dt = 10f;
        DRAW.col = new Color(0.8f, 0.8f, 0.8f);

        DRAW.QUAD(new Vector3(2f, 2f, 0f), 0.96f, 1f / 20 , true , false , false , false);
        DRAW.QUAD(new Vector3(3f, 2f, 0f), 0.96f, 1f / 20 , true , false , true , false);
        DRAW.QUAD(new Vector3(4f, 2f, 0f), 0.96f, 1f / 20 , false , true , true , false);
        DRAW.QUAD(new Vector3(4f, 3f, 0f), 0.96f, 1f / 20 , false , true , false , true);
        DRAW.QUAD(new Vector3(4f, 4f, 0f), 0.96f, 1f / 20 , false , false , false , true);


        while(true)
        {


            yield return null;
        }
        */ 
        #endregion



        DRAW.dt = Time.deltaTime;

        while(true)
        {


            if(Input.GetMouseButton(0))
            {
                int X = Mathf.RoundToInt(pos2D.x),
                    Y = Mathf.RoundToInt(pos2D.y);

                //
                if(X >= 0 && X < _BOARD_2D_.GetLength(0) &&
                   Y >= 0 && Y < _BOARD_2D_.GetLength(1) )
                {
                    _BOARD_2D_[X, Y] = 0;

                         if (Input.GetKey(KeyCode.Alpha1)) { _BOARD_2D_[X, Y] = 1; }
                    else if (Input.GetKey(KeyCode.Alpha2)) { _BOARD_2D_[X, Y] = 2; }
                    else if (Input.GetKey(KeyCode.Alpha3)) { _BOARD_2D_[X, Y] = 3; }
                }
                //
            }

            if(Input.GetMouseButtonDown(2))
            {
                break;
            }


            for (int y = 0; y < _BOARD_2D_.GetLength(1); y += 1)
            {
                for (int x = 0; x < _BOARD_2D_.GetLength(0); x += 1)
                {
                         if (_BOARD_2D_[x, y] == -1) { DRAW.col = Color.HSVToRGB(0.00f, 0.0f, 0.3f); }
                    else if (_BOARD_2D_[x, y] == +0) { DRAW.col = Color.HSVToRGB(0.00f, 0.35f, 0.80f); }
                    else if (_BOARD_2D_[x, y] == +1) { DRAW.col = Color.HSVToRGB(0.16f, 0.25f, 0.65f); }
                    else if (_BOARD_2D_[x, y] == +2) { DRAW.col = Color.HSVToRGB(0.00f, 0.35f, 0.80f); }
                    else if (_BOARD_2D_[x, y] == +3) { DRAW.col = Color.HSVToRGB(0.16f, 0.25f, 0.65f); }



                    //DRAW.QUAD(new Vector3(x, y, 0f), 0.95f, 1f / 20);
                    DRAW.QUAD(new Vector3(x, y, 0f), 0.95f, 1f / 20, _corner : (_BOARD_2D_[x, y ] == 2) || (_BOARD_2D_[x, y] == 3),

                            (x + 1 < _BOARD_2D_.GetLength(0)) ? (_BOARD_2D_[x + 1, y + 0] == _BOARD_2D_[x, y]) : false,
                            (y + 1 < _BOARD_2D_.GetLength(1)) ? (_BOARD_2D_[x + 0, y + 1] == _BOARD_2D_[x, y]) : false,
                            (x - 1 >= 0                     ) ? (_BOARD_2D_[x - 1, y + 0] == _BOARD_2D_[x, y]) : false,
                            (y - 1 >= 0                     ) ? (_BOARD_2D_[x + 0, y - 1] == _BOARD_2D_[x, y]) : false

                    );



                    //
                }
            }
            //





            yield return null;

        }

        Debug.Log(FLOOD_FILL(_BOARD_2D_).Count);





        DRAW.dt = Time.deltaTime;
        #region DRAW

        int draw_mode = 0;
        while (true)
        {
    
            for (int y = 0; y < _BOARD_2D_.GetLength(1); y += 1)
            {
                for (int x = 0; x < _BOARD_2D_.GetLength(0); x += 1)
                {
                         if (_BOARD_2D_[x, y] == -1) { DRAW.col = Color.HSVToRGB(0.00f, 0.0f, 0.3f); }
                    else if (_BOARD_2D_[x, y] == +0) { DRAW.col = Color.HSVToRGB(0.00f, 0.35f, 0.80f); }
                    else if (_BOARD_2D_[x, y] == +1) { DRAW.col = Color.HSVToRGB(0.16f, 0.25f, 0.65f); }
                    else if (_BOARD_2D_[x, y] == +2) { DRAW.col = Color.HSVToRGB(0.00f, 0.35f, 0.80f); }
                    else if (_BOARD_2D_[x, y] == +3) { DRAW.col = Color.HSVToRGB(0.16f, 0.25f, 0.65f); }



                    if (draw_mode == 0) { DRAW.QUAD(new Vector3(x, y, 0f), 0.95f, 1f / 20); }
                    else if(draw_mode == 1)
                    {
                        DRAW.QUAD(new Vector3(x, y, 0f), 0.95f, 1f / 20, (_BOARD_2D_[x, y] == 2) || (_BOARD_2D_[x, y] == 3),

                           (x + 1 < _BOARD_2D_.GetLength(0)) ? (_BOARD_2D_[x + 1, y + 0] == _BOARD_2D_[x, y]) : false,
                           (y + 1 < _BOARD_2D_.GetLength(1)) ? (_BOARD_2D_[x + 0, y + 1] == _BOARD_2D_[x, y]) : false,
                           (x - 1 >= 0                     ) ? (_BOARD_2D_[x - 1, y + 0] == _BOARD_2D_[x, y]) : false,
                           (y - 1 >= 0                     ) ? (_BOARD_2D_[x + 0, y - 1] == _BOARD_2D_[x, y]) : false

                       );
                    }
                    //
                }
            }


            if (Input.GetMouseButtonDown(2))
            {
                draw_mode = (draw_mode + 1) % 2;
            }
            yield return null;
        }
        #endregion



        #region _CONSTRUUCOTR_.... INITIALIZE , PROPAGATE
        /*
       _CONSTRUCTOR_._INITIALIZE();

       while (true)
       {
           _CONSTRUCTOR_._PROPAGATE(new bool[4] { false, true, false, false });

           yield return new WaitForSeconds(2f);
       }
       */
        #endregion

        yield return null;
    }


    public Camera cam;

    #region pos2D
    public Vector2 pos2D
    {
        get
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            Vector3 a = ray.origin,
                    n = ray.direction;
            Vector3 o = Vector3.zero,
                   up = Vector3.forward;

            float L = Vector3.Dot(-(a - o), up) / Vector3.Dot(n, up);

            return a + n * L;


        }
    } 
    #endregion






    #region _CONSTRUCTOR_TOOL_

    static List<List<int[]>> FLOOD_FILL(int[,] BOARD)
    {
        int x_L = BOARD.GetLength(0),
            y_L = BOARD.GetLength(1);


        bool[,] _evaluated_2D = new bool[x_L, y_L];

        for (int y = 0; y < y_L; y += 1)
        {
            for (int x = 0; x < x_L; x += 1)
            {
                _evaluated_2D[x, y] = false;
                if (BOARD[x, y] == -1) { _evaluated_2D[x, y] = true; }
            }
        }





        List<List<int[]>> region_1D = new List<List<int[]>>();


        for (int y0 = 0; y0 < y_L; y0 += 1)
        {
            for (int x0 = 0; x0 < x_L; x0 += 1)
            {
                if (_evaluated_2D[x0, y0]) { continue; }




                List<int[]> _region = new List<int[]>();
                _region.Add(new int[2] { x0, y0 });
                _evaluated_2D[x0, y0] = true;

                while (true)
                {
                    bool one_of_it_got_evaluated = false;

                    for (int i0 = 0; i0 < _region.Count; i0 += 1)
                    {
                        int[][] _dirs = new int[4][]
                        {
                                new int[2] { +1 , +0 },
                                new int[2] { +0 , +1 },
                                new int[2] { -1 , +0 },
                                new int[2] { +0 , -1 },
                        };

                        for (int i1 = 0; i1 < _dirs.Length; i1 += 1)
                        {


                            int X = _region[i0][0] + _dirs[i1][0],
                                Y = _region[i0][1] + _dirs[i1][1];
                            if (X >= 0 && X < x_L &&
                                Y >= 0 && Y < y_L)
                            {
                                if (!_evaluated_2D[X, Y])
                                {
                                    //
                                    if (BOARD[X, Y] == BOARD[_region[i0][0], _region[i0][1]])
                                    {
                                        _region.Add(new int[2] { X, Y });
                                        _evaluated_2D[X, Y] = true;

                                        one_of_it_got_evaluated = true;
                                    }
                                    //
                                }
                            }
                            //


                        }
                        //

                    }



                    if (!one_of_it_got_evaluated) { break; }
                }


                region_1D.Add(_region);

            }

        }





        return region_1D;
    }

    #endregion





    #region _CONSTRUCTOR_

    public static class _CONSTRUCTOR_
    {
        /* Relation */

        static int[][] Rs_IYs;
        static int[][] Ys_IRs;
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







        /* switch  */

        static bool[] Rs;
        static bool[] Ys;
        static bool[] IRs;
        static bool[] IYs;
        static bool[] M;





        /* BOARD */
        static int[,][] Rs_Ys_IRs_IYs__M__via_;



        public static void _INITIALIZE()
        {


            List<List<int[]>> Rs_region_1D;
            List<List<int[]>> Ys_region_1D;
            List<List<int[]>> IRs_region_1D;
            List<List<int[]>> IYs_region_1D;

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



        public static void _PROPAGATE(bool[] curr_M_switch)
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
        #region flood_fill

        /*
    static List<List<int[]>> FLOOD_FILL(int[,] BOARD)
    {
        int x_L = BOARD.GetLength(0),
            y_L = BOARD.GetLength(1);


        bool[,] _evaluated_2D = new bool[x_L, y_L];

        for (int y = 0; y < y_L; y += 1)
        {
            for (int x = 0; x < x_L; x += 1)
            {
                _evaluated_2D[x, y] = false;
                if (BOARD[x, y] == -1) { _evaluated_2D[x, y] = true; }
            }
        }





        List<List<int[]>> region_1D = new List<List<int[]>>();


        for (int y0 = 0; y0 < y_L; y += 1)
        {
            for (int x0 = 0; x0 < x_L; x += 1)
            {
                if (_evaluated[x, y]) { continue; }




                List<int[]> _region = new List<int[]>();
                region.Add(new int[2] { x0, y0 });
                _evaluated_2D[x, y] = true;

                while (true)
                {
                    bool one_of_it_got_evaluated = false;

                    for (int i0 = 0; i0 < _region.Count; i0 += 1)
                    {
                        int[][] _dirs = new int[4][]
                        {
                            new int[2] { +1 , +0 },
                            new int[2] { +0 , +1 },
                            new int[2] { -1 , +0 },
                            new int[2] { +0 , -1 },
                        };

                        for (int i1 = 0; i1 < _dirs.length; i1 += 1)
                        {


                            int X = _region[i0][0] + _dirs[i1][0],
                                Y = _region[i0][1] + _dirs[i1][1];
                            if (X >= 0 && X < x_l &&
                                Y >= 0 && Y < y_l)
                            {
                                if (!_evaluated_2D[X, Y])
                                {
                                    //
                                    if (BOARD[X, Y] == BOARD[_region[i0][0], _region[i0][1]])
                                    {
                                        _region.Add(new int[2] { X, Y });
                                        _evaluated_2D[X, Y] = true;

                                        one_of_it_got_evaluated = true;
                                    }
                                    //
                                }
                            }
                            //


                        }
                        //

                    }



                    if (!one_of_it_got_evaluated) { break; }
                }


                region_1D.Add(region);

            }

        }





        return region_1D;
    }
    //....................//

    */
        #endregion




        #region get_region_index , neighbour_region_index_1D__of_type

        /*
        static int get_region_index_from_pos(List<List<int[]>> region_1D, int[] _pos)
        {


            for (int i0 = 0; i0 < region_1D.Count; i0 += 1)
            {
                for (int i1 = 0; i1 < region_1D[i0].Count; i1 += 1)
                {
                    if (region_1D[i0][i1][0] == _pos[0] && region_1D[i0][i1][1] == _pos[1])
                    {
                        return i0;
                    }
                }
            }

            return -10;

        }
        //






        static int[] _neighbour_region_index_1D_of_type_(int[,] BOARD, int _curr_region_index, List<List<int[]>> region_1D, int _type)
        {

            List<int> _neighbour_region_index_1D = new List<int>();


            for (int i0 = 0; i0 < region_1D[_curr_region_index].Count; i0 += 1)
            {
                int[][] _dirs = new int[4][]
                {
                    new int[2] { +1 , +0 },
                    new int[2] { +0 , +1 },
                    new int[2] { -1 , +0 },
                    new int[2] { +0 , -1 },
                };



                for (int i1 = 0; i1 < _dirs.Length; i1 += 1)
                {
                    int X = region_1D[_curr_region_index][0] + _dirs[i1][0],
                        Y = region_1D[_curr_region_index][1] + _dirs[i1][1];

                    int neighbour_region_index = get_region_index_from_pos(X, Y);

                    if (neighbour_region_index != _curr_region_index)
                    {

                        //
                        //
                        if (BOARD[X, Y] == _type)
                        {
                            if (!_neighbour_region_index_1D.Contains(neighbour_region_index))
                            {
                                _neighbour_region_index_1D.Add(neighbour_region_index);
                            }
                        }

                        //
                    }
                }

            }
            //

            return _neighbour_region_index_1D;

        }
        */
        #endregion

    }

    #endregion



    #region DRAW
    public static class DRAW
    {
        public static float dt;
        public static Color col = Color.red;



        public static void QUAD(Vector3 o, float s, float e = 1f/20)
        {

            Vector3[] _corners_A = new Vector3[4]
            {
                new Vector3(+s/2 , +s/2),
                new Vector3(-s/2 , +s/2),
                new Vector3(-s/2 , -s/2),
                new Vector3(+s/2 , -s/2),
            };


            Vector3[] _corners_B = new Vector3[4]
            {
                new Vector3(+s/2  - e , +s/2 - e),
                new Vector3(-s/2  + e , +s/2 - e),
                new Vector3(-s/2  + e , -s/2 + e),
                new Vector3(+s/2  - e , -s/2 + e),
            };


            for (int i = 0; i < _corners_A.Length; i += 1)
            {
                Debug.DrawLine(o + _corners_A[i], o + _corners_A[(i + 1) % _corners_A.Length], col, dt);
                Debug.DrawLine(o + _corners_B[i], o + _corners_B[(i + 1) % _corners_B.Length], col, dt);
            }



        }


        public static void QUAD(Vector3 o, float s, float e = 1f / 20, params bool[] neighbour_state_1D)
        {

            Vector3[] _corners_A = new Vector3[4]
            {
                new Vector3(+s/2 , -s/2),
                new Vector3(+s/2 , +s/2),
                new Vector3(-s/2 , +s/2),
                new Vector3(-s/2 , -s/2),
            };


            Vector3[] _corners_B = new Vector3[4]
            {
                new Vector3(+s/2  - e , -s/2 + e),
                new Vector3(+s/2  - e , +s/2 - e),
                new Vector3(-s/2  + e , +s/2 - e),
                new Vector3(-s/2  + e , -s/2 + e),
            };


            for (int i = 0; i < _corners_A.Length; i += 1)
            {
                if (!neighbour_state_1D[i])
                {

                    Debug.DrawLine(o + _corners_A[i], o + _corners_A[(i + 1) % _corners_A.Length], col, dt);
                    Debug.DrawLine(o + _corners_B[i], o + _corners_B[(i + 1) % _corners_B.Length], col, dt);
                }
            }



        }


        public static void QUAD(Vector3 o, float s, float e = 1f / 20, bool _corner = true, params bool[] neighbour_state_1D)
        {

            Vector3[] _corners_A = new Vector3[4]
            {
                new Vector3(+s/2 , -s/2),
                new Vector3(+s/2 , +s/2),
                new Vector3(-s/2 , +s/2),
                new Vector3(-s/2 , -s/2),
            };


            Vector3[] _corners_B = new Vector3[4]
            {
                new Vector3(+s/2  - e , -s/2 + e),
                new Vector3(+s/2  - e , +s/2 - e),
                new Vector3(-s/2  + e , +s/2 - e),
                new Vector3(-s/2  + e , -s/2 + e),
            };


            for (int i = 0; i < _corners_A.Length; i += 1)
            {
                if (!neighbour_state_1D[i])
                {

                    Debug.DrawLine(o + _corners_A[i], o + _corners_A[(i + 1) % _corners_A.Length], col, dt);
                    Debug.DrawLine(o + _corners_B[i], o + _corners_B[(i + 1) % _corners_B.Length], col, dt);
                }
            }




            //
            float _size = 1f / 15;
            if (_corner)
            {
                List<int> index_1D = new List<int>();
                for (int i = 0; i < neighbour_state_1D.Length; i += 1)
                {
                    if (neighbour_state_1D[i]) { index_1D.Add(i); }
                }


                if (index_1D.Count == 1 ||
                    index_1D.Count == 0 ||
                   (index_1D.Count == 2 && index_1D[0] + 2 % 4 != index_1D[1]))
                {
                    Debug.DrawLine(o + Vector3.up * _size, o - Vector3.up * _size, col, dt);
                    Debug.DrawLine(o + Vector3.right * _size, o - Vector3.right * _size, col, dt);
                }

            }
                //

                

        }
    }



    #endregion




}





