using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class DEBUG_CONSTRUCTOR_2_2_0_ : MonoBehaviour
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




        for (int y = 0; y < _CONSTRUCTOR_.BOARD_2D_.GetLength(1); y += 1)
        {
            for (int x = 0; x < _CONSTRUCTOR_.BOARD_2D_.GetLength(0); x += 1)
            {
                _CONSTRUCTOR_.BOARD_2D_[x, y] = -1;

                _CONSTRUCTOR_.BOARD_2D_M_[x, y] = -1;
                _CONSTRUCTOR_.BOARD_2D_M_via_[x, y] = -1;
            }
        }
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


                    if      (Input.GetKey(KeyCode.Alpha1)) { _CONSTRUCTOR_.BOARD_2D_[X, Y] = +0; }
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


                    else if (Input.GetKey(KeyCode.Space))
                    {
                        _CONSTRUCTOR_.BOARD_2D_[X, Y] = -1;
                        _CONSTRUCTOR_.BOARD_2D_M_[X, Y] = -1;
                        _CONSTRUCTOR_.BOARD_2D_M_via_[X, Y] = -1;

                    }


                }


            }
            ////// INPUT //////





            #region DRAW
            ////// DRAW //////
            DRAW.INITIALIZE();
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
            ////// DRAW ////// 
            #endregion


            if (Input.GetMouseButtonDown(2))
            {
                break;
            }


            yield return null;
        }




        Debug.Log( _TOOL_.FLOOD_FILL(_CONSTRUCTOR_.BOARD_2D_).Count);
        _TOOL_.region_1D_1D(_CONSTRUCTOR_.BOARD_2D_,_TOOL_.FLOOD_FILL(_CONSTRUCTOR_.BOARD_2D_));

        /*
        Debug.Log(_CONSTRUCTOR_.region_1D_Rs_.Count);
        Debug.Log(_CONSTRUCTOR_.region_1D_Ys_.Count);
        Debug.Log(_CONSTRUCTOR_.region_1D_IRs_.Count);
        Debug.Log(_CONSTRUCTOR_.region_1D_IYs_.Count);
        */


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
			_TOOL_.relation_of_type_A_region__to__type_B_region_neighbour_(_CONSTRUCTOR_.region_1D_Rs_, _CONSTRUCTOR_.region_1D_TYs_),
		);



        str = "";
        for (int i0 = 0; i0 < _relate_0.Length; i0 += 1)
        {
            str += "---";
            for (int i1 = 0; i1 < _relate_0.Length[i0].Length; i1 += 1)
            {
				str += "--";
				for (int i2 = 0; i2 < _relate_0.Length[i0][i1].Length; i2 += 1)
				{
					str += _relate_0.Length[i0][i1][i2] + ", ";
				}
                
            }
            //

        }
        Debug.Log(str);
		
		
		








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

        public static void INITIALIZE()
        {
            //
            BOARD_2D_ = new int[10, 10];
            BOARD_2D_M_ = new int[BOARD_2D_.GetLength(0), BOARD_2D_.GetLength(1)];
            BOARD_2D_M_via_ = new int[BOARD_2D_.GetLength(0), BOARD_2D_.GetLength(1)];
        }


        static bool[] Rs_switch_;
        static bool[] Ys_switch_;
        static bool[] IRs_switch_;
        static bool[] IYs_switch_;
        static bool[] M_switch_;



        public static List<List<int[]>> region_1D_Rs_;
        public static List<List<int[]>> region_1D_Ys_;
        public static List<List<int[]>> region_1D_IRs_;
        public static List<List<int[]>> region_1D_IYs_;
        public static List<List<int[]>> region_1D_M_;




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
            _TOOL_.region_1D_1D(BOARD_2D_ , _TOOL_.FLOOD_FILL(BOARD_2D_));
            region_1D_M_ = _TOOL_.FLOOD_FILL(BOARD_2D_M_);



            Rs_switch_ = new bool[region_1D_Rs_.Count];
            Ys_switch_ = new bool[region_1D_Ys_.Count];
            IRs_switch_ = new bool[region_1D_IRs_.Count];
            IYs_switch_ = new bool[region_1D_IYs_.Count];
            M_switch_ = new bool[region_1D_M_.Count];



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

        }




        //.... _PROPAGATE ....//

        public static void _PROPAGATE(bool[] curr_M_switch_)
        {
            //.... curr_M_switch , prev_IRs__IYs_switch ....//
            for (int i = 0; i < M_switch_.Length; i += 1)
            {
                M_switch_[i] = curr_M_switch_[i];
            }
            //

            bool[] prev_IRs_switch_ = new bool[IRs_switch_.Length];
            bool[] prev_IYs_switch_ = new bool[IYs_switch_.Length];




            //.... iter ....//
            for (int iter = 0; iter < 30; iter += 1)
            {


                //.... Rs ....//
                for (int i0 = 0; i0 < Rs_switch_.Length; i0 += 1)
                {
                    if (Rs_switch_[i0])
                    {
                        for (int i1 = 0; i1 < Rs_IYs.Length; i1 += 1)
                        {
                            for (int i2 = 0; i2 < Rs_IYs_Rs[i0][i1].Length; i2 += 1)
                            {
                                if (prev_IYs_switch_[Rs_IYs[i0][i1]]) { Rs_switch_[Rs_IYs_Rs[i0][i1][i2]] = true; }
                            }
                        }


                        for (int i1 = 0; i1 < Rs_M.Length; i1 += 1) { M_switch_[Rs_M[i0][i1]] = true; }


                    }
                }
                //.... Rs ....//


                //.... Ys ....//
                for (int i0 = 0; i0 < Ys_switch_.Length; i0 += 1)
                {
                    if (Ys_switch_[i0])
                    {
                        for (int i1 = 0; i1 < Ys_IRs.Length; i1 += 1)
                        {
                            for (int i2 = 0; i2 < Ys_IRs_Ys[i0][i1].Length; i2 += 1)
                            {
                                if (!prev_IRs_switch_[Ys_IRs[i0][i1]]) { Ys_switch_[Ys_IRs_Ys[i0][i1][i2]] = true; }

                            }
                        }


                        for (int i1 = 0; i1 < Ys_M.Length; i1 += 1) { M_switch_[Ys_M[i0][i1]] = true; }


                    }
                }
                //.... Ys ....//



                // .... IRs .... //
                for (int i0 = 0; i0 < IRs_switch_.Length; i0 += 1)
                {

                    if (IRs_switch_[i0]) { for (int i1 = 0; i1 < IRs_M.Length; i1 += 1) { M_switch_[IRs_M[i0][i1]] = true; } }

                }
                // .... IRs .... //


                // .... IYs .... //
                for (int i0 = 0; i0 < IYs_switch_.Length; i0 += 1)
                {

                    if (IYs_switch_[i0]) { for (int i1 = 0; i1 < IYs_M.Length; i1 += 1) { M_switch_[IYs_M[i0][i1]] = true; } }

                }
                // .... IYs .... //




                // .... M .... //
                for (int i0 = 0; i0 < M_switch_.Length; i0 += 1)
                {

                    if (M_switch_[i0])
                    {
                        for (int i1 = 0; i1 < M_Rs.Length; i1 += 1) { Rs_switch_[M_Rs[i0][i1]] = true; }
                        for (int i1 = 0; i1 < M_Ys.Length; i1 += 1) { Ys_switch_[M_Ys[i0][i1]] = true; }
                        for (int i1 = 0; i1 < M_IRs.Length; i1 += 1) { IRs_switch_[M_IRs[i0][i1]] = true; }
                        for (int i1 = 0; i1 < M_IYs.Length; i1 += 1) { IYs_switch_[M_IYs[i0][i1]] = true; }


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
    }



    #endregion

}
