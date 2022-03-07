using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class DEBUG_CONSTRUCTOR_2_1_0_ : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StopAllCoroutines();
            StartCoroutine(STIMULATE());
        }
        //
    }

    IEnumerator STIMULATE()
    {
        #region frame_rate

        QualitySettings.vSyncCount = 4;
        yield return null;
        yield return null;

        #endregion


        _CONSTRUCTOR_.INITIALIZE();




        
        //



        while (true)
        {


            ////// INPUT //////
            if (Input.GetMouseButton(0))
            {
                int X = Mathf.RoundToInt(pos2D.x),
                     Y = Mathf.RoundToInt(pos2D.y);

                if (X >= 0 && X < _CONSTRUCTOR_.BOARD_2D_.GetLength(0) &&
                    Y >= 0 && Y < _CONSTRUCTOR_.BOARD_2D_.GetLength(1))
                {


                    if (Input.GetKey(KeyCode.Alpha1)) { _CONSTRUCTOR_.BOARD_2D_[X, Y] = +0; }
                    else if (Input.GetKey(KeyCode.Alpha2)) { _CONSTRUCTOR_.BOARD_2D_[X, Y] = +1; }
                    else if (Input.GetKey(KeyCode.Alpha3)) { _CONSTRUCTOR_.BOARD_2D_[X, Y] = +2; }
                    else if (Input.GetKey(KeyCode.Alpha4)) { _CONSTRUCTOR_.BOARD_2D_[X, Y] = +3; }



                    else if (Input.GetKey(KeyCode.Alpha5)) { _CONSTRUCTOR_.BOARD_2D_M_[X, Y] = 0; }
                    else if (Input.GetKey(KeyCode.Alpha6))
                    {
                        if (_CONSTRUCTOR_.BOARD_2D_[X, Y] != -1 && _CONSTRUCTOR_.BOARD_2D_M_[X, Y] == +0)
                        {
                            _CONSTRUCTOR_.BOARD_2D_M_via_[X, Y] = 0;
                        }
                        //
                    }
                    else if (Input.GetKey(KeyCode.I))
                    {
                        _CONSTRUCTOR_.BOARD_2D_In_[X, Y] = +0;
                    }




                    else if (Input.GetKey(KeyCode.Space))
                    {
                        _CONSTRUCTOR_.BOARD_2D_[X, Y] = -1;
                        _CONSTRUCTOR_.BOARD_2D_M_[X, Y] = -1;
                        _CONSTRUCTOR_.BOARD_2D_M_via_[X, Y] = -1;
                        _CONSTRUCTOR_.BOARD_2D_In_[X, Y] = -1;
                    }


                }


            }
            ////// INPUT //////



            #region DRAW
            ////// DRAW //////
            DRAW.INITIALIZE();
            DRAW.dt = Time.deltaTime;
            for (int y = 0; y < _CONSTRUCTOR_.BOARD_2D_In_.GetLength(1); y += 1)
            {
                for (int x = 0; x < _CONSTRUCTOR_.BOARD_2D_In_.GetLength(0); x += 1)
                {

                    if (_CONSTRUCTOR_.BOARD_2D_In_[x, y] == +0)
                    {

                        DRAW.col = Color.HSVToRGB(0.0f, 0.0f, 0.4f);

                        /*
                        //....QUAD ....//
                        DRAW.QUAD(new Vector3(x, y, 10f), 0.96f, 1f / 40,
                            _corner_highlight: false,
                            (x + 1 < _CONSTRUCTOR_.BOARD_2D_.GetLength(0)) ? (_CONSTRUCTOR_.BOARD_2D_In_[x + 1, y + 0] == _CONSTRUCTOR_.BOARD_2D_In_[x, y]) : false,
                            (y + 1 < _CONSTRUCTOR_.BOARD_2D_.GetLength(1)) ? (_CONSTRUCTOR_.BOARD_2D_In_[x + 0, y + 1] == _CONSTRUCTOR_.BOARD_2D_In_[x, y]) : false,
                            (x - 1 >= 0) ? (_CONSTRUCTOR_.BOARD_2D_In_[x - 1, y + 0] == _CONSTRUCTOR_.BOARD_2D_In_[x, y]) : false,
                            (y - 1 >= 0) ? (_CONSTRUCTOR_.BOARD_2D_In_[x + 0, y - 1] == _CONSTRUCTOR_.BOARD_2D_In_[x, y]) : false


                        );
                        //....QUAD ....//
                        */

                        DRAW.QUAD(new Vector3(x, y, 0f), 0.60f);
                    }
                    


                }
            }



            DRAW.dt = Time.deltaTime;
            for (int y = 0; y < _CONSTRUCTOR_.BOARD_2D_.GetLength(1); y += 1)
            {
                for (int x = 0; x < _CONSTRUCTOR_.BOARD_2D_.GetLength(0); x += 1)
                {

                    if (_CONSTRUCTOR_.BOARD_2D_M_[x, y] == +0)
                    {
                        DRAW.col = Color.HSVToRGB(0f, 0f, 0.7f);

                        //....QUAD ....//
                        DRAW.QUAD(new Vector3(x, y, 0f), 0.3f, 1f / 50
                        );
                        //....QUAD ....//
                    }


                    if (_CONSTRUCTOR_.BOARD_2D_M_via_[x, y] == +0)
                    {
                        DRAW.col = Color.HSVToRGB(0.6f, 0.4f, 0.9f);

                        //....QUAD ....//
                        DRAW.QUAD(new Vector3(x, y, 0f), 0.4f, 1f / 50
                        );
                        //....QUAD ....//
                    }

                }
            }




            DRAW.dt = Time.deltaTime;
            for (int y = 0; y < _CONSTRUCTOR_.BOARD_2D_.GetLength(1); y += 1)
            {
                for (int x = 0; x < _CONSTRUCTOR_.BOARD_2D_.GetLength(0); x += 1)
                {
                         if (_CONSTRUCTOR_.BOARD_2D_[x, y] == -1) { DRAW.col = DRAW.col_1D[0]; }
                    else if (_CONSTRUCTOR_.BOARD_2D_[x, y] == +0) { DRAW.col = DRAW.col_1D[1]; }
                    else if (_CONSTRUCTOR_.BOARD_2D_[x, y] == +1) { DRAW.col = DRAW.col_1D[2]; }
                    else if (_CONSTRUCTOR_.BOARD_2D_[x, y] == +2) { DRAW.col = DRAW.col_1D[1]; }
                    else if (_CONSTRUCTOR_.BOARD_2D_[x, y] == +3) { DRAW.col = DRAW.col_1D[2]; }





                    //....QUAD ....//
                    DRAW.QUAD(new Vector3(x, y, -5f), 0.96f, 1f / 40,

                        _corner_highlight: (_CONSTRUCTOR_.BOARD_2D_[x, y] == 2 || _CONSTRUCTOR_.BOARD_2D_[x, y] == 3),

                        (x + 1 < _CONSTRUCTOR_.BOARD_2D_.GetLength(0)) ? (_CONSTRUCTOR_.BOARD_2D_[x + 1, y + 0] == _CONSTRUCTOR_.BOARD_2D_[x, y]) : false,
                        (y + 1 < _CONSTRUCTOR_.BOARD_2D_.GetLength(1)) ? (_CONSTRUCTOR_.BOARD_2D_[x + 0, y + 1] == _CONSTRUCTOR_.BOARD_2D_[x, y]) : false,
                        (x - 1 >= 0                                  ) ? (_CONSTRUCTOR_.BOARD_2D_[x - 1, y + 0] == _CONSTRUCTOR_.BOARD_2D_[x, y]) : false,
                        (y - 1 >= 0                                  ) ? (_CONSTRUCTOR_.BOARD_2D_[x + 0, y - 1] == _CONSTRUCTOR_.BOARD_2D_[x, y]) : false
                                                                     

                    );
                    //....QUAD ....//


                }
            }


            ////// DRAW ////// 
            ///


            #endregion


            if (Input.GetMouseButtonDown(2))
            {
                break;
            }


            yield return null;
        }



        _CONSTRUCTOR_.INITIALIZE_REGION();
        _CONSTRUCTOR_.INITIALIZE__switch__RELATION();



        LOG._1D_1D(_CONSTRUCTOR_.Rs_M);
        Debug.Log(_TOOL_.FLOOD_FILL(_CONSTRUCTOR_.BOARD_2D_M_).Count);








        int _iter = 0;
        while(true)
        {


            _iter += 1; 

            if(_iter % 20 == 0)
            {
                _CONSTRUCTOR_._PROPAGATE();
            }



            #region DRAW
            ////// DRAW //////
            DRAW.INITIALIZE();
            DRAW.dt = Time.deltaTime;
            for (int y = 0; y < _CONSTRUCTOR_.BOARD_2D_In_.GetLength(1); y += 1)
            {
                for (int x = 0; x < _CONSTRUCTOR_.BOARD_2D_In_.GetLength(0); x += 1)
                {

                    if (_CONSTRUCTOR_.BOARD_2D_In_[x, y] == +0)
                    {

                        DRAW.col = Color.HSVToRGB(0.0f, 0.0f, 0.4f);

                        /*
                        //....QUAD ....//
                        DRAW.QUAD(new Vector3(x, y, 10f), 0.96f, 1f / 40,
                            _corner_highlight: false,
                            (x + 1 < _CONSTRUCTOR_.BOARD_2D_.GetLength(0)) ? (_CONSTRUCTOR_.BOARD_2D_In_[x + 1, y + 0] == _CONSTRUCTOR_.BOARD_2D_In_[x, y]) : false,
                            (y + 1 < _CONSTRUCTOR_.BOARD_2D_.GetLength(1)) ? (_CONSTRUCTOR_.BOARD_2D_In_[x + 0, y + 1] == _CONSTRUCTOR_.BOARD_2D_In_[x, y]) : false,
                            (x - 1 >= 0) ? (_CONSTRUCTOR_.BOARD_2D_In_[x - 1, y + 0] == _CONSTRUCTOR_.BOARD_2D_In_[x, y]) : false,
                            (y - 1 >= 0) ? (_CONSTRUCTOR_.BOARD_2D_In_[x + 0, y - 1] == _CONSTRUCTOR_.BOARD_2D_In_[x, y]) : false


                        );
                        //....QUAD ....//
                        */

                        DRAW.QUAD(new Vector3(x, y, 0f), 0.60f, 1f / 40);
                    }



                }
            }



            DRAW.dt = Time.deltaTime;
            for (int y = 0; y < _CONSTRUCTOR_.BOARD_2D_.GetLength(1); y += 1)
            {
                for (int x = 0; x < _CONSTRUCTOR_.BOARD_2D_.GetLength(0); x += 1)
                {

                    if (_CONSTRUCTOR_.BOARD_2D_M_[x, y] == +0)
                    {
                        DRAW.col = Color.HSVToRGB(0f, 0f, 0.7f);

                        //....QUAD ....//
                        DRAW.QUAD(new Vector3(x, y, 0f), 0.3f, 1f / 50
                        );
                        //....QUAD ....//
                    }


                    if (_CONSTRUCTOR_.BOARD_2D_M_via_[x, y] == +0)
                    {
                        DRAW.col = Color.HSVToRGB(0.6f, 0.4f, 0.9f);

                        //....QUAD ....//
                        DRAW.QUAD(new Vector3(x, y, 0f), 0.4f, 1f / 50
                        );
                        //....QUAD ....//
                    }

                }
            }




            DRAW.dt = Time.deltaTime;
            for (int y = 0; y < _CONSTRUCTOR_.BOARD_2D_.GetLength(1); y += 1)
            {
                for (int x = 0; x < _CONSTRUCTOR_.BOARD_2D_.GetLength(0); x += 1)
                {
                    if (_CONSTRUCTOR_.BOARD_2D_[x, y] == -1) { DRAW.col = DRAW.col_1D[0]; }
                    else if (_CONSTRUCTOR_.BOARD_2D_[x, y] == +0) { DRAW.col = DRAW.col_1D[1]; }
                    else if (_CONSTRUCTOR_.BOARD_2D_[x, y] == +1) { DRAW.col = DRAW.col_1D[2]; }
                    else if (_CONSTRUCTOR_.BOARD_2D_[x, y] == +2) { DRAW.col = DRAW.col_1D[1]; }
                    else if (_CONSTRUCTOR_.BOARD_2D_[x, y] == +3) { DRAW.col = DRAW.col_1D[2]; }





                    //....QUAD ....//
                    DRAW.QUAD(new Vector3(x, y, -5f), 0.96f, 1f / 40,

                        _corner_highlight: (_CONSTRUCTOR_.BOARD_2D_[x, y] == 2 || _CONSTRUCTOR_.BOARD_2D_[x, y] == 3),

                        (x + 1 < _CONSTRUCTOR_.BOARD_2D_.GetLength(0)) ? (_CONSTRUCTOR_.BOARD_2D_[x + 1, y + 0] == _CONSTRUCTOR_.BOARD_2D_[x, y]) : false,
                        (y + 1 < _CONSTRUCTOR_.BOARD_2D_.GetLength(1)) ? (_CONSTRUCTOR_.BOARD_2D_[x + 0, y + 1] == _CONSTRUCTOR_.BOARD_2D_[x, y]) : false,
                        (x - 1 >= 0) ? (_CONSTRUCTOR_.BOARD_2D_[x - 1, y + 0] == _CONSTRUCTOR_.BOARD_2D_[x, y]) : false,
                        (y - 1 >= 0) ? (_CONSTRUCTOR_.BOARD_2D_[x + 0, y - 1] == _CONSTRUCTOR_.BOARD_2D_[x, y]) : false


                    );
                    //....QUAD ....//


                }
            }


            ////// DRAW ////// 
            ///


            #endregion


            #region DRAW
            //

            DRAW.col = Color.HSVToRGB(0f, 0f, 0.6f);
            for (int i0 = 0; i0 < _CONSTRUCTOR_.In_switch_.Length; i0 += 1)
            {
                for (int i1 = 0; i1 < _CONSTRUCTOR_.region_1D_In_[i0].Count; i1 += 1)
                {
                    //

                    if (_CONSTRUCTOR_.In_switch_[i0])
                        DRAW.QUAD_charge(
                            new Vector3()
                            {
                                x = _CONSTRUCTOR_.region_1D_In_[i0][i1][0],
                                y = _CONSTRUCTOR_.region_1D_In_[i0][i1][1]
                            }, 0.16f
                        );

                    //



                }
                
            }

            //


            for (int i0 = 0; i0 < _CONSTRUCTOR_.Rs_switch_.Length; i0 += 1)
            {
                for (int i1 = 0; i1 < _CONSTRUCTOR_.region_1D_Rs_[i0].Count; i1 += 1)
                {

                    if (_CONSTRUCTOR_.Rs_switch_[i0])
                        DRAW.QUAD_charge(
                            new Vector3()
                            {
                                x = _CONSTRUCTOR_.region_1D_Rs_[i0][i1][0],
                                y = _CONSTRUCTOR_.region_1D_Rs_[i0][i1][1]
                            }, 0.16f
                        );

                    //



                }

            }

            for (int i0 = 0; i0 < _CONSTRUCTOR_.M_switch_.Length; i0 += 1)
            {
                for (int i1 = 0; i1 < _CONSTRUCTOR_.region_1D_M_[i0].Count; i1 += 1)
                {

                    if (_CONSTRUCTOR_.M_switch_[i0])
                        DRAW.QUAD_charge(
                            new Vector3()
                            {
                                x = _CONSTRUCTOR_.region_1D_M_[i0][i1][0],
                                y = _CONSTRUCTOR_.region_1D_M_[i0][i1][1]
                            }, 0.16f
                        );

                    //



                }

            }

            for (int i0 = 0; i0 < _CONSTRUCTOR_.IYs_switch_.Length; i0 += 1)
            {
                for (int i1 = 0; i1 < _CONSTRUCTOR_.region_1D_IYs_[i0].Count; i1 += 1)
                {

                    if (_CONSTRUCTOR_.IYs_switch_[i0])
                        DRAW.QUAD_charge(
                            new Vector3()
                            {
                                x = _CONSTRUCTOR_.region_1D_IYs_[i0][i1][0],
                                y = _CONSTRUCTOR_.region_1D_IYs_[i0][i1][1]
                            }, 0.16f
                        );

                    //



                }

            }

            #endregion








            if (Input.GetMouseButtonDown(0))
            {
                int X = Mathf.RoundToInt(pos2D.x),
                    Y = Mathf.RoundToInt(pos2D.y);

                int _region_index = _TOOL_.region_index_at_X_Y_(_CONSTRUCTOR_.region_1D_In_, X, Y);

                if(_region_index != -10)
                {
                    _CONSTRUCTOR_.In_switch_[_region_index] = !_CONSTRUCTOR_.In_switch_[_region_index];
                }
                //
            }


            yield return null;
        }







        #region str
        /*
        Debug.Log(_TOOL_.FLOOD_FILL(_CONSTRUCTOR_.BOARD_2D_).Count);
        _TOOL_.region_1D_1D(_CONSTRUCTOR_.BOARD_2D_, _TOOL_.FLOOD_FILL(_CONSTRUCTOR_.BOARD_2D_));




        int[][] _neighbour_region_index_1D =
            _TOOL_.relation_of_type_A_region__to__type_B_region_neighbour_
            (_CONSTRUCTOR_.region_1D_Rs_, _CONSTRUCTOR_.region_1D_IYs_);


        string str = "";
        for (int i0 = 0; i0 < _neighbour_region_index_1D.Length; i0 += 1)
        {
            str += "--";
            for (int i1 = 0; i1 < _neighbour_region_index_1D[i0].Length; i1 += 1)
            {
                str += _neighbour_region_index_1D[i0][i1] + ", ";
            }
            //
        }
        Debug.Log(str);



        _neighbour_region_index_1D =
            _TOOL_.relation_of_type_A_region__to__type_B_region_neighbour_
            (_CONSTRUCTOR_.region_1D_IYs_, _CONSTRUCTOR_.region_1D_Rs_);


        str = "";
        for (int i0 = 0; i0 < _neighbour_region_index_1D.Length; i0 += 1)
        {
            str += "--";
            for (int i1 = 0; i1 < _neighbour_region_index_1D[i0].Length; i1 += 1)
            {
                str += _neighbour_region_index_1D[i0][i1] + ", ";
            }
            //
        }
        Debug.Log(str);









        // _relate_0
        int[][][] _relate_0 = _TOOL_._relate_silicon__Isilicon(
            _TOOL_.relation_of_type_A_region__to__type_B_region_neighbour_(_CONSTRUCTOR_.region_1D_IYs_, _CONSTRUCTOR_.region_1D_Rs_),
            _TOOL_.relation_of_type_A_region__to__type_B_region_neighbour_(_CONSTRUCTOR_.region_1D_Rs_, _CONSTRUCTOR_.region_1D_IYs_)

        );



        str = "";
        for (int i0 = 0; i0 < _relate_0.Length; i0 += 1)
        {
            str += "//";
            for (int i1 = 0; i1 < _relate_0[i0].Length; i1 += 1)
            {
                str += "--";
                for (int i2 = 0; i2 < _relate_0[i0][i1].Length; i2 += 1)
                {
                    str += _relate_0[i0][i1][i2] + ", ";
                }

            }
            //

        }
        Debug.Log(str);





        // _relate_0
        _relate_0 = _TOOL_._relate_silicon__Isilicon(
            _TOOL_.relation_of_type_A_region__to__type_B_region_neighbour_(_CONSTRUCTOR_.region_1D_Rs_, _CONSTRUCTOR_.region_1D_IYs_),
            _TOOL_.relation_of_type_A_region__to__type_B_region_neighbour_(_CONSTRUCTOR_.region_1D_IYs_, _CONSTRUCTOR_.region_1D_Rs_)

        );



        str = "";
        for (int i0 = 0; i0 < _relate_0.Length; i0 += 1)
        {
            str += "//";
            for (int i1 = 0; i1 < _relate_0[i0].Length; i1 += 1)
            {
                str += "--";
                for (int i2 = 0; i2 < _relate_0[i0][i1].Length; i2 += 1)
                {
                    str += _relate_0[i0][i1][i2] + ", ";
                }

            }
            //

        }
        Debug.Log(str);

*/
        #endregion



        #region DRAW
        ////// DRAW //////
        DRAW.dt = 10f;
        for (int y = 0; y < _CONSTRUCTOR_.BOARD_2D_.GetLength(1); y += 1)
        {
            for (int x = 0; x < _CONSTRUCTOR_.BOARD_2D_.GetLength(0); x += 1)
            {
                if (_CONSTRUCTOR_.BOARD_2D_[x, y] == -1) { DRAW.col = DRAW.col_1D[0]; }
                else if (_CONSTRUCTOR_.BOARD_2D_[x, y] == +0) { DRAW.col = DRAW.col_1D[1]; }
                else if (_CONSTRUCTOR_.BOARD_2D_[x, y] == +1) { DRAW.col = DRAW.col_1D[2]; }
                else if (_CONSTRUCTOR_.BOARD_2D_[x, y] == +2) { DRAW.col = DRAW.col_1D[1]; }
                else if (_CONSTRUCTOR_.BOARD_2D_[x, y] == +3) { DRAW.col = DRAW.col_1D[2]; }





                //....QUAD ....//
                DRAW.QUAD(new Vector3(x, y, 0f), 0.96f, 1f / 30,

                    _corner_highlight: (_CONSTRUCTOR_.BOARD_2D_[x, y] == 2 || _CONSTRUCTOR_.BOARD_2D_[x, y] == 3),

                    (x + 1 < _CONSTRUCTOR_.BOARD_2D_.GetLength(0)) ? (_CONSTRUCTOR_.BOARD_2D_[x + 1, y + 0] == _CONSTRUCTOR_.BOARD_2D_[x, y]) : false,
                    (y + 1 < _CONSTRUCTOR_.BOARD_2D_.GetLength(1)) ? (_CONSTRUCTOR_.BOARD_2D_[x + 0, y + 1] == _CONSTRUCTOR_.BOARD_2D_[x, y]) : false,
                    (x - 1 >= 0) ? (_CONSTRUCTOR_.BOARD_2D_[x - 1, y + 0] == _CONSTRUCTOR_.BOARD_2D_[x, y]) : false,
                    (y - 1 >= 0) ? (_CONSTRUCTOR_.BOARD_2D_[x + 0, y - 1] == _CONSTRUCTOR_.BOARD_2D_[x, y]) : false


                );
                //....QUAD ....//


            }
        }


        for (int y = 0; y < _CONSTRUCTOR_.BOARD_2D_.GetLength(1); y += 1)
        {
            for (int x = 0; x < _CONSTRUCTOR_.BOARD_2D_.GetLength(0); x += 1)
            {

                if (_CONSTRUCTOR_.BOARD_2D_M_[x, y] == +0)
                {
                    DRAW.col = Color.HSVToRGB(0f, 0f, 0.7f);

                    //....QUAD ....//
                    DRAW.QUAD(new Vector3(x, y, 0f), 0.3f, 1f / 50
                    );
                    //....QUAD ....//
                }


                if (_CONSTRUCTOR_.BOARD_2D_M_via_[x, y] == +0)
                {
                    DRAW.col = Color.HSVToRGB(0.6f, 0.4f, 0.9f);

                    //....QUAD ....//
                    DRAW.QUAD(new Vector3(x, y, 0f), 0.4f, 1f / 50
                    );
                    //....QUAD ....//
                }

            }
        }
        ////// DRAW ////// 
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





    public static class _CONSTRUCTOR_
    {

        public static int[,] BOARD_2D_;
        public static int[,] BOARD_2D_M_;
        public static int[,] BOARD_2D_M_via_;


        public static int[,] BOARD_2D_In_;



        public static void INITIALIZE()
        {
            //
            BOARD_2D_ = new int[10, 10];
            BOARD_2D_M_ = new int[BOARD_2D_.GetLength(0), BOARD_2D_.GetLength(1)];
            BOARD_2D_M_via_ = new int[BOARD_2D_.GetLength(0), BOARD_2D_.GetLength(1)];
            BOARD_2D_In_ = new int[BOARD_2D_.GetLength(0), BOARD_2D_.GetLength(1)];

            //
            for (int y = 0; y < BOARD_2D_.GetLength(1); y += 1)
            {
                for (int x = 0; x < BOARD_2D_.GetLength(0); x += 1)
                {
                    BOARD_2D_[x, y] = -1;

                    BOARD_2D_M_[x, y] = -1;
                    BOARD_2D_M_via_[x, y] = -1;

                    BOARD_2D_In_[x, y] = -1;
                }
            }
            //

        }



        public static bool[] In_switch_;

        public static bool[] Rs_switch_;
        public static bool[] Ys_switch_;
        public static bool[] IRs_switch_;
        public static bool[] IYs_switch_;
        public static bool[] M_switch_;


        public static List<List<int[]>> region_1D_In_;

        public static List<List<int[]>> region_1D_Rs_;
        public static List<List<int[]>> region_1D_Ys_;
        public static List<List<int[]>> region_1D_IRs_;
        public static List<List<int[]>> region_1D_IYs_;
        public static List<List<int[]>> region_1D_M_;


        public static int[][] In_M;

        public static int[][] Rs_IYs;
        public static int[][] Ys_IRs;
        public static int[][] IRs_Ys;
        public static int[][] IYs_Rs;

        public static int[][][] Rs_IYs_Rs;
        public static int[][][] Ys_IRs_Ys;


        public static int[][] Rs_M;
        public static int[][] Ys_M;

        public static int[][] IRs_M;
        public static int[][] IYs_M;
        
        public static int[][] M_Rs;
        public static int[][] M_Ys;
        public static int[][] M_IRs;
        public static int[][] M_IYs;



        public static void INITIALIZE_REGION()
        {

            region_1D_M_ = _TOOL_.FLOOD_FILL(BOARD_2D_M_);
            region_1D_In_ = _TOOL_.FLOOD_FILL(BOARD_2D_In_);




            List<List<int[]>> region_1D_S = _TOOL_.FLOOD_FILL(BOARD_2D_);

            region_1D_Rs_ = new List<List<int[]>>();
            region_1D_Ys_ = new List<List<int[]>>();
            region_1D_IRs_ = new List<List<int[]>>();
            region_1D_IYs_ = new List<List<int[]>>();
           
            for (int i0 = 0; i0 < region_1D_S.Count; i0 += 1)
            {
                if      (BOARD_2D_[region_1D_S[i0][0][0], region_1D_S[i0][0][1]] == 0) { region_1D_Rs_.Add(region_1D_S[i0]); }
                else if (BOARD_2D_[region_1D_S[i0][0][0], region_1D_S[i0][0][1]] == 1) { region_1D_Ys_.Add(region_1D_S[i0]); }
                else if (BOARD_2D_[region_1D_S[i0][0][0], region_1D_S[i0][0][1]] == 2) { region_1D_IRs_.Add(region_1D_S[i0]); }
                else if (BOARD_2D_[region_1D_S[i0][0][0], region_1D_S[i0][0][1]] == 3) { region_1D_IYs_.Add(region_1D_S[i0]); }

            }

            //
        }



        public static void INITIALIZE__switch__RELATION()
        {

            Rs_switch_ = new bool[region_1D_Rs_.Count];
            Ys_switch_ = new bool[region_1D_Ys_.Count];
            IRs_switch_ = new bool[region_1D_IRs_.Count];
            IYs_switch_ = new bool[region_1D_IYs_.Count];
            M_switch_ = new bool[region_1D_M_.Count];

            In_switch_ = new bool[region_1D_In_.Count];



            Rs_IYs = _TOOL_.relation_of_type_A_region__to__type_B_region_neighbour_(region_1D_Rs_, region_1D_IYs_);
            Ys_IRs = _TOOL_.relation_of_type_A_region__to__type_B_region_neighbour_(region_1D_Ys_, region_1D_IRs_);
            IYs_Rs = _TOOL_.relation_of_type_A_region__to__type_B_region_neighbour_(region_1D_IYs_, region_1D_Rs_);
            IRs_Ys = _TOOL_.relation_of_type_A_region__to__type_B_region_neighbour_(region_1D_IRs_, region_1D_Ys_);



            Rs_IYs_Rs = _TOOL_._relate_silicon__Isilicon(Rs_IYs, IYs_Rs);
            Ys_IRs_Ys = _TOOL_._relate_silicon__Isilicon(Ys_IRs, IRs_Ys);





            Rs_M = _TOOL_.relation_of_type_A_region__to__type_B_region_via_(region_1D_Rs_, region_1D_M_, BOARD_2D_M_via_);
            Ys_M = _TOOL_.relation_of_type_A_region__to__type_B_region_via_(region_1D_Ys_, region_1D_M_, BOARD_2D_M_via_);
            IRs_M = _TOOL_.relation_of_type_A_region__to__type_B_region_via_(region_1D_IRs_, region_1D_M_, BOARD_2D_M_via_);
            IYs_M = _TOOL_.relation_of_type_A_region__to__type_B_region_via_(region_1D_IYs_, region_1D_M_, BOARD_2D_M_via_);

            M_Rs = _TOOL_.relation_of_type_A_region__to__type_B_region_via_(region_1D_M_, region_1D_Rs_, BOARD_2D_M_via_);
            M_Ys = _TOOL_.relation_of_type_A_region__to__type_B_region_via_(region_1D_M_, region_1D_Ys_, BOARD_2D_M_via_);
            M_IRs = _TOOL_.relation_of_type_A_region__to__type_B_region_via_(region_1D_M_, region_1D_IRs_, BOARD_2D_M_via_);
            M_IYs = _TOOL_.relation_of_type_A_region__to__type_B_region_via_(region_1D_M_, region_1D_IYs_, BOARD_2D_M_via_);

            In_M = _TOOL_.relation_of_type_A_region__to__type_B_region_OnTop_(region_1D_In_, region_1D_M_);

        }




        //.... _PROPAGATE ....//

        public static void _PROPAGATE()
        {
            //.... curr_M_switch , prev_IRs__IYs_switch ....//


            for (int i = 0; i <  M_switch_.Length; i += 1) { M_switch_[i]  = false; }
            for (int i = 0; i < Rs_switch_.Length; i += 1) { Rs_switch_[i] = false; }
            for (int i = 0; i < Ys_switch_.Length; i += 1) { Ys_switch_[i] = false; }



            #region In_switch_ - M_switch_
            for (int i0 = 0; i0 < In_M.Length; i0 += 1)
            {
                for (int i1 = 0; i1 < In_M[i0].Length; i1 += 1)
                {
                    M_switch_[In_M[i0][i1]] = In_switch_[i0];
                    //

                }
            } 
            #endregion





            bool[] prev_IRs_switch_ = new bool[IRs_switch_.Length];
            bool[] prev_IYs_switch_ = new bool[IYs_switch_.Length];

            #region I_s_switch_ - prev_I_s_switch_
            for (int i = 0; i < IRs_switch_.Length; i += 1) { prev_IRs_switch_[i] = IRs_switch_[i]; }
            for (int i = 0; i < IYs_switch_.Length; i += 1) { prev_IYs_switch_[i] = IYs_switch_[i]; } 
            #endregion



            for (int i = 0; i < IRs_switch_.Length; i += 1) { IRs_switch_[i] = false; }
            for (int i = 0; i < IYs_switch_.Length; i += 1) { IYs_switch_[i] = false; }
            







            //.... iter ....//
            for (int iter = 0; iter < 30; iter += 1)
            {


                //.... Rs ....//
                for (int i0 = 0; i0 < Rs_switch_.Length; i0 += 1)
                {
                    if (Rs_switch_[i0])
                    {
                        for (int i1 = 0; i1 < Rs_IYs[i0].Length; i1 += 1)
                        {
                            for (int i2 = 0; i2 < Rs_IYs_Rs[i0][i1].Length; i2 += 1)
                            {
                                if (prev_IYs_switch_[Rs_IYs[i0][i1]]) { Rs_switch_[Rs_IYs_Rs[i0][i1][i2]] = true; }
                            }
                        }


                        for (int i1 = 0; i1 < Rs_M[i0].Length; i1 += 1) { M_switch_[Rs_M[i0][i1]] = true; }


                    }
                }
                //.... Rs ....//


                //.... Ys ....//
                for (int i0 = 0; i0 < Ys_switch_.Length; i0 += 1)
                {
                    if (Ys_switch_[i0])
                    {
                        for (int i1 = 0; i1 < Ys_IRs[i0].Length; i1 += 1)
                        {
                            for (int i2 = 0; i2 < Ys_IRs_Ys[i0][i1].Length; i2 += 1)
                            {
                                if (!prev_IRs_switch_[Ys_IRs[i0][i1]]) { Ys_switch_[Ys_IRs_Ys[i0][i1][i2]] = true; }

                            }
                        }


                        for (int i1 = 0; i1 < Ys_M[i0].Length; i1 += 1) { M_switch_[Ys_M[i0][i1]] = true; }


                    }
                }
                //.... Ys ....//



                // .... IRs .... //
                for (int i0 = 0; i0 < IRs_switch_.Length; i0 += 1)
                {

                    if (IRs_switch_[i0]) { for (int i1 = 0; i1 < IRs_M[i0].Length; i1 += 1) { M_switch_[IRs_M[i0][i1]] = true; } }

                }
                // .... IRs .... //


                // .... IYs .... //
                for (int i0 = 0; i0 < IYs_switch_.Length; i0 += 1)
                {

                    if (IYs_switch_[i0]) { for (int i1 = 0; i1 < IYs_M[i0].Length; i1 += 1) { M_switch_[IYs_M[i0][i1]] = true; } }

                }
                // .... IYs .... //




                // .... M .... //
                for (int i0 = 0; i0 < M_switch_.Length; i0 += 1)
                {

                    if (M_switch_[i0])
                    {
                        for (int i1 = 0; i1 < M_Rs[i0].Length; i1 += 1) { Rs_switch_[M_Rs[i0][i1]] = true; }
                        for (int i1 = 0; i1 < M_Ys[i0].Length; i1 += 1) { Ys_switch_[M_Ys[i0][i1]] = true; }
                        for (int i1 = 0; i1 < M_IRs[i0].Length; i1 += 1) { IRs_switch_[M_IRs[i0][i1]] = true; }
                        for (int i1 = 0; i1 < M_IYs[i0].Length; i1 += 1) { IYs_switch_[M_IYs[i0][i1]] = true; }


                    }

                }
                // .... M .... //






            }
            //.... iter ....//


        }
        //.... _PROPAGATE ....//





        #region TOOL

        #endregion









    }




    public static class LOG
    {
        public static void _1D_1D(int[][] Rs_M)
        {
            string str = "";

            
            for (int i0 = 0; i0 < Rs_M.Length; i0 += 1)
            {
                str += "--";
                for (int i1 = 0; i1 < Rs_M[i0].Length; i1 += 1)
                {
                    str += Rs_M[i0][i1] + ", ";
                }

            }



            Debug.Log(str);
        }


    }



    #region DRAW
    public static class DRAW
    {
        public static float dt;
        public static Color col = Color.red;



        public static Color[] col_1D;

        public static void INITIALIZE()
        {
            col_1D = new Color[3]
            {
                Color.HSVToRGB( 0.00f , 0.00f , 0.30f ),
                Color.HSVToRGB( 0.00f , 0.30f , 0.84f ),
                Color.HSVToRGB( 0.15f , 0.25f , 0.70f ),
            };
            //
        }




        public static void QUAD(Vector3 o, float s, float e = 1f / 20)
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


        public static void QUAD(Vector3 o, float s, float e = 1f / 20, bool _corner_highlight = true, params bool[] neighbour_state_1D)
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
            if (_corner_highlight)
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





        public static void QUAD_charge(Vector3 o , float _offset = 0.20f)
        {
            float _size = 1f / 20;


            
            Vector3[] _P = new Vector3[5]
            {
                new Vector2(+0.0f , +0.0f),
                new Vector2(+_offset , +_offset),
                new Vector2(-_offset , +_offset),
                new Vector2(-_offset , -_offset),
                new Vector2(+_offset , -_offset),
            };


            for (int i = 0; i < _P.Length; i += 1)
            {

                Debug.DrawLine(o + _P[i] + Vector3.up * _size   , o + _P[i] - Vector3.up * _size, col, dt);
                Debug.DrawLine(o + _P[i] + Vector3.right * _size, o + _P[i] - Vector3.right * _size, col, dt);
            }
            //
        }




    }



    #endregion

}