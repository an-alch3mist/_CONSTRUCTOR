using UnityEngine;
using System.Collections;
using System.Collections.Generic;




#region DEBUG_CONSTRUCTOR_0.....

public class DEBUG_CONSTRUCTOR_0 : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StopAllCoroutines();
            StartCoroutine(STIMULATE());
        }
    }




    IEnumerator STIMULATE()
    {
        #region frame_rate
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 4;
        yield return null;
        yield return null;

        #endregion



        int N = 5;
        int[,] BOARD_2D = new int[N + 1, N + 1];

        for (int y = 0; y <= N; y += 1)
        {
            for (int x = 0; x <= N; x += 1)
            {
                BOARD_2D[x, y] = 0;
            }
        }


        DRAW.dt = Time.deltaTime;

        while (true)
        {

            if (Input.GetMouseButton(0))
            {
                int X = Mathf.RoundToInt(this.pos2D.x),
                    Y = Mathf.RoundToInt(this.pos2D.y);


                if (X >= 0 && X <= N && Y >= 0 && Y <= N)
                {
                    BOARD_2D[X, Y] = 1;
                }
                //
            }


            if (Input.GetMouseButtonDown(2))
            {

                Debug.Log(REGION_TOOL._Flood_Fill(BOARD_2D).Count);
                Debug.Log("...");
                for (int i = 0; i < REGION_TOOL._Flood_Fill(BOARD_2D).Count; i += 1)
                {
                    Debug.Log(REGION_TOOL._Flood_Fill(BOARD_2D)[i].Count);
                }

            }


            for (int y = 0; y <= N; y += 1)
            {
                for (int x = 0; x <= N; x += 1)
                {
                    //
                    DRAW.col = Color.HSVToRGB(0f, 0f, 0.4f);
                    if (BOARD_2D[x, y] == 1)
                    { DRAW.col = Color.HSVToRGB(0f, 0.5f, 0.9f); }

                    DRAW.QUAD(new Vector3(x, y, 0f), 1f);

                    //

                }
            }


            yield return null;
        }



        yield return null;
        //
    }





    public static class REGION_TOOL
    {


        public static List<List<int[]>> _Flood_Fill(int[,] BOARD_2D)
        {
            int x_L = BOARD_2D.GetLength(0),
                y_L = BOARD_2D.GetLength(1);

            bool[,] BOARD_2D_evaluate = new bool[x_L, y_L];



            #region INITIALIZE BOARD_2D_wvaluate
            //
            for (int y = 0; y < y_L; y += 1)
            {
                for (int x = 0; x < x_L; x += 1)
                {
                    BOARD_2D_evaluate[x, y] = false;
                }
            }
            // 
            #endregion



            List<List<int[]>> _REGION_1D = new List<List<int[]>>();


            #region evaluate_entire_board
            while (true)
            {

                for (int y = 0; y < y_L; y += 1)
                {
                    for (int x = 0; x < x_L; x += 1)
                    {
                        //
                        if (BOARD_2D_evaluate[x, y]) { continue; }




                        List<int[]> _region = new List<int[]>();

                        _region.Add(new int[2] { x, y });
                        BOARD_2D_evaluate[x, y] = true;


                        int _state = BOARD_2D[x, y];



                        while (true)
                        {

                            #region INITIALIZE_neighbours
                            int[][] _neighbour = new int[4][]
                            {
                                new int[2] { +1 , +0 },
                                new int[2] { +0 , +1 },
                                new int[2] { -1 , +0 },
                                new int[2] { +0 , -1 },
                            };
                            #endregion


                            bool found_one_need_to_be_evaluated = false;

                            #region neighbour_split
                            for (int i0 = 0; i0 < _region.Count; i0 += 1)
                            {
                                for (int i1 = 0; i1 < _neighbour.Length; i1 += 1)
                                {

                                    int X = _region[i0][0] + _neighbour[i1][0],
                                        Y = _region[i0][1] + _neighbour[i1][1];

                                    if (X >= 0 && X < x_L && Y >= 0 && Y < y_L)
                                    {
                                        if (!BOARD_2D_evaluate[X, Y])
                                        {
                                            if (BOARD_2D[X, Y] == _state)
                                            {
                                                _region.Add(new int[2] { X, Y });

                                                found_one_need_to_be_evaluated = true;
                                                BOARD_2D_evaluate[X, Y] = true;
                                            }
                                            //
                                        }

                                    }






                                }
                                //
                            }
                            #endregion


                            if (!found_one_need_to_be_evaluated) { break; }

                        }
                        //



                        _REGION_1D.Add(_region);

                        //

                    }
                }






                //


                //
                #region _entire_board_evaluated....break
                bool _entire_BOARD_evaluated = true;
                for (int y = 0; y < y_L; y += 1)
                {
                    for (int x = 0; x < x_L; x += 1)
                    {
                        if (!BOARD_2D_evaluate[x, y])
                        {
                            _entire_BOARD_evaluated = false;
                            break;
                        }
                        //
                    }
                }

                if (_entire_BOARD_evaluated) { break; }
                #endregion







            }
            #endregion


            return _REGION_1D;
            //
        }



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
            //
        }

    }
    #endregion





    #region DRAW
    public static class DRAW
    {
        public static float dt = 1f;
        public static Color col = Color.red;


        public static void QUAD(Vector3 o, float s_0, float s_0_t = 0.95f, float s_1_t = 0.88f)
        {
            float r = Mathf.Sqrt(s_0 * s_0 + s_0 * s_0) / 2f;

            for (int i = 0; i < 4; i += 1)
            {
                Vector3 a = new Vector3()
                {
                    x = Mathf.Cos(Mathf.PI / 4 + Mathf.PI / 2 * i),
                    y = Mathf.Sin(Mathf.PI / 4 + Mathf.PI / 2 * i),
                } * r;

                Vector3 b = new Vector3()
                {
                    x = Mathf.Cos(Mathf.PI / 4 + Mathf.PI / 2 * (i + 1)),
                    y = Mathf.Sin(Mathf.PI / 4 + Mathf.PI / 2 * (i + 1)),
                } * r;


                Debug.DrawLine(o + a * s_0_t, o + b * s_0_t, col, dt);
                Debug.DrawLine(o + a * s_1_t, o + b * s_1_t, col, dt);

            }

        }

        //

        public static void LINE(Vector3 a, Vector3 b, float e = 0f)
        {
            Vector3 n = b - a;
            n = new Vector3(-n.y, n.x).normalized;


            Debug.DrawLine(a + n * e, b + n * e, col, dt);
            Debug.DrawLine(a - n * e, b - n * e, col, dt);

        }

        //

    }
    #endregion





}

#endregion









public class DEBUG_CONSTRUCTOR_1 : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StopAllCoroutines();
            StartCoroutine(STIMULATE());
        }
    }



    #region STIMULATE

    IEnumerator STIMULATE()
    {
        #region frame_rate
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 4;
        yield return null;
        yield return null;

        #endregion



        int N = 5;
        int[,][] _info_BOARD_2D = new int[N + 1, N + 1][];

        #region INITIAlIZE_info_BOARD_2D
        for (int y = 0; y <= N; y += 1)
        {
            for (int x = 0; x <= N; x += 1)
            {

                _info_BOARD_2D[x, y] = new int[3]
                {
                    -1, - 1, -1
                };
                //
            }
        }
        #endregion





        DRAW.dt = Time.deltaTime;

        while (true)
        {

            _INPUT_.paint_info_BOARD_2D(this.pos2D, _info_BOARD_2D);
            //


            //
            DRAW.ad_info_BOARD(_info_BOARD_2D);






            if (Input.GetMouseButtonDown(2))
            {

                PROCCESS(_info_BOARD_2D);
                //
            }


            yield return null;
        }



        yield return null;
        //
    }



    #endregion











    #region PROCESS
    public void PROCCESS(int[,][] _info_BOARD_2D)
    {
        /*    
                           -1           0                     1  
        0 ... silicon...  empty   or  N-silicon         or   P-silicon
        1 ... metal  ...  empty   or  metal             or  
        2 ... via    ...  empty   or  meta-silicon-via  or  

        */


        int x_L = _info_BOARD_2D.GetLength(0),
            y_L = _info_BOARD_2D.GetLength(1);

        #region _BOARD_2D_silicon
        int[,] _BOARD_2D_silicon = new int[x_L, y_L];

        for (int y = 0; y < y_L; y += 1)
        {
            for (int x = 0; x < x_L; x += 1)
            {
                _BOARD_2D_silicon[x, y] = _info_BOARD_2D[x, y][0];



                //
            }
        }
        // 
        #endregion



        #region _BOARD_2D_metal
        int[,] _BOARD_2D_metal = new int[x_L, y_L];

        for (int y = 0; y < y_L; y += 1)
        {
            for (int x = 0; x < x_L; x += 1)
            {
                _BOARD_2D_metal[x, y] = _info_BOARD_2D[x, y][1];



                //
            }
        }
        // 
        #endregion



        List<List<int[]>> silicon_region_1D = REGION_TOOL._Flood_Fill(_BOARD_2D_silicon);
        List<List<int[]>> metal_region_1D = REGION_TOOL._Flood_Fill(_BOARD_2D_metal);





        bool[] metal_state_1D = new bool[metal_region_1D.Count];
        List<List<int>> metal__silicon_1D__1D = new List<List<int>>();



        // metal

        #region INITIALIZE_metal_state_1D, metal__silicon__1D
        for (int i = 0; i < metal_state_1D.Length; i += 1)
        {
            metal_state_1D[i] = false;
        }



        for (int i0 = 0; i0 < metal_region_1D.Count; i0 += 1)
        {
            List<int> metal__silicon_1D = new List<int>();


            for (int i1 = 0; i1 < metal_region_1D[i0].Count; i1 += 1)
            {
                int X = metal_region_1D[i0][i1][0],
                    Y = metal_region_1D[i0][i1][1];

                if (_info_BOARD_2D[X, Y][2] == -1) { continue; }


                int _index = REGION_TOOL._region_containing_pos(new int[2] { X, Y }, silicon_region_1D);

                if (!metal__silicon_1D.Contains(_index))
                {
                    metal__silicon_1D.Add(_index);

                }
            }



            metal__silicon_1D__1D.Add(metal__silicon_1D);
        }
        #endregion



        //
        #region DEBUG... L< L<int> > str
        string str = "";

        for (int i0 = 0; i0 < metal__silicon_1D__1D.Count; i0 += 1)
        {
            str += "{ ";
            for (int i1 = 0; i1 < metal__silicon_1D__1D[i0].Count; i1 += 1)
            {
                str += metal__silicon_1D__1D[i0][i1] + ", ";
            }
            str += " }";
        }

        // Debug.Log(str); 

        #endregion





        // silicon

        bool[] silicon_state_1D = new bool[silicon_region_1D.Count];
        int[] silicon_type_1D = new int[silicon_region_1D.Count];

        List<List<int>> __silicon_1D__1D = new List<List<int>>();
        List<List<List<int>>> __silicon_1D__1D__1D = new List<List<List<int>>>();
        List<List<int>> silicon__metal_1D__1D = new List<List<int>>();




        #region INITIALIZE silicon_state_1D, silicon_type_1D, __silicon_1D__1D, __silicon_1D__1D__1D, __metal_1D__1D

        for (int i = 0; i < silicon_state_1D.Length; i += 1)
        { silicon_state_1D[i] = false; }


        for (int i = 0; i < silicon_region_1D.Count; i += 1)
        {
            int _state = _info_BOARD_2D[silicon_region_1D[i][0][0], silicon_region_1D[i][0][1]][0];
            silicon_type_1D[i] = _state;
        }



        str = "";
        for (int i0 = 0; i0 < silicon_type_1D.Length; i0 += 1)
        {
            str += silicon_type_1D[i0] + ", ";
        }
        Debug.Log(str);







        int[][] _dirs = new int[4][]
        {
            new int[2] { +1 , +0 },
            new int[2] { +1 , +1 },
            new int[2] { -1 , +0 },
            new int[2] { +0 , -1 },
        };


        for (int i0 = 0; i0 < silicon_region_1D.Count; i0 += 1)
        {
            List<int> neighbour_silicon_1D = new List<int>();
            for (int i1 = 0; i1 < silicon_region_1D[i0].Count; i1 += 1)
            {

                for (int i2 = 0; i2 < _dirs.Length; i2 += 1)
                {
                    int X = silicon_region_1D[i0][i1][0] + _dirs[i2][0],
                        Y = silicon_region_1D[i0][i1][1] + _dirs[i2][1];


                    int _index = REGION_TOOL._region_containing_pos(new int[2] { X, Y }, silicon_region_1D);
                    if (_index == i0 || _index == -100) { continue; }


                    if (!neighbour_silicon_1D.Contains(_index))
                    {
                        neighbour_silicon_1D.Add(_index);
                    }
                }


            }


            __silicon_1D__1D.Add(neighbour_silicon_1D);
            //
        }







        str = "";
        for (int i0 = 0; i0 < __silicon_1D__1D.Count; i0 += 1)
        {
            str += "{ ";
            for (int i1 = 0; i1 < __silicon_1D__1D[i0].Count; i1 += 1)
            {
                str += __silicon_1D__1D[i0][i1] + ", ";
            }
            str += "} ";
        }

        Debug.Log(str);








        for (int i0 = 0; i0 < __silicon_1D__1D.Count; i0 += 1)
        {

            __silicon_1D__1D__1D.Add(new List<List<int>>());
            //
            for (int i1 = 0; i1 < __silicon_1D__1D[i0].Count; i1 += 1)
            {
                // an_opposite_neighbour_silicon

                int _index = __silicon_1D__1D[i0][i1];

                List<int> new_neighbours_excluding_i0 = new List<int>();
                for (int i2 = 0; i2 < __silicon_1D__1D[_index].Count; i2 += 1)
                {
                    if (__silicon_1D__1D[_index][i2] != i0)
                    {
                        new_neighbours_excluding_i0.Add(__silicon_1D__1D[_index][i2]);
                    }
                }

                __silicon_1D__1D__1D[i0].Add(new_neighbours_excluding_i0);

            }
            //
        }



        str = "";
        for (int i0 = 0; i0 < __silicon_1D__1D__1D.Count; i0 += 1)
        {
            str += "{ ";
            for (int i1 = 0; i1 < __silicon_1D__1D__1D[i0].Count; i1 += 1)
            {


                str += "{ ";
                for (int i2 = 0; i2 < __silicon_1D__1D__1D[i0][i1].Count; i2 += 1)
                {
                    str += __silicon_1D__1D__1D[i0][i1][i2] + ", ";
                }
                str += " }, ";


                //
            }
            str += " }, ";
        }

        Debug.Log(str);





        for (int i0 = 0; i0 < silicon_region_1D.Count; i0 += 1)
        {
            //
            silicon__metal_1D__1D.Add(new List<int>());
            for (int i1 = 0; i1 < silicon_region_1D[i0].Count; i1 += 1)
            {
                //
                int X = silicon_region_1D[i0][i1][0],
                    Y = silicon_region_1D[i0][i1][1];

                if (_info_BOARD_2D[X, Y][2] == -1) { continue; }


                int _index = REGION_TOOL._region_containing_pos(new int[2] { X, Y }, metal_region_1D);

                if (!silicon__metal_1D__1D[i0].Contains(_index))
                {
                    silicon__metal_1D__1D[i0].Add(_index);
                }
                //
            }
            //
        }



        str = "";
        for (int i0 = 0; i0 < silicon__metal_1D__1D.Count; i0 += 1)
        {
            str += "{ ";
            //
            for (int i1 = 0; i1 < silicon__metal_1D__1D[i0].Count; i1 += 1)
            {
                str += silicon__metal_1D__1D[i0][i1] + ", ";
            }
            //
            str += "}, ";
        }



        Debug.Log(str);
        #endregion





        if (metal_state_1D.Length != 0) { metal_state_1D[0] = true; }



        PROPAGATE(
            metal_state_1D, metal__silicon_1D__1D,
            silicon_state_1D , silicon_type_1D,
            __silicon_1D__1D, __silicon_1D__1D__1D,
            silicon__metal_1D__1D
        );




        str = "";
        for(int i = 0; i < silicon_state_1D.Length; i += 1)
        {
            if (silicon_state_1D[i]) { str += '1'; }
            else                     { str += '0'; }
        }

        Debug.Log(str);

        str = "";
        for (int i = 0; i < metal_state_1D.Length; i += 1)
        {
            if (metal_state_1D[i]) { str += '1'; }
            else                   { str += '0'; }
        }
        Debug.Log(str);


    }
    #endregion



    /*
    TODO
        silicon - previous_state..... silicon
                  curr_state.... metal
        
        metal - curr_state...... silicon
    */




    #region PROPAGATE
    public void PROPAGATE(

        bool[] metal_state_1D , List<List<int>> metal__silicon_1D__1D ,

        bool[] silicon_state_1D, int[] silicon_type_1D,
        List<List<int>> __silicon_1D__1D, List<List<List<int>>> __silicon_1D__1D__1D,
        List<List<int>> silicon__metal_1D__1D
    )
    {
        //
        for(int iter = 0; iter < 10; iter += 1)
        {

            // metal

            for (int i0 = 0; i0 < metal_state_1D.Length; i0 += 1)
            {
                if (metal_state_1D[i0]) { continue; }
                //

                
                for(int i1 = 0; i1 < metal__silicon_1D__1D[i0].Count; i1 += 1)
                {
                    if(silicon_state_1D[metal__silicon_1D__1D[i0][i1]])
                    {
                        metal_state_1D[i0] = true;
                        break;
                    }
                }


            }



            // silicon
            for(int i0 = 0; i0 < silicon_state_1D.Length; i0 += 1)
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
                        if (silicon_state_1D[__silicon_1D__1D[i0][i1]])
                        {
                            //
                            for (int i2 = 0; i2 < __silicon_1D__1D__1D[i0][i1].Count; i2 += 1)
                            {
                                sum += 1;
                            }
                            //

                        }
                    }

                    if (sum > 0) { silicon_state_1D[i0] = true; }
                    else         { silicon_state_1D[i0] = false; }

                }



                else if (silicon_type_1D[i0] == 1)
                {

                    int sum = 0;
                    for (int i1 = 0; i1 < __silicon_1D__1D[i0].Count; i1 += 1)
                    {
                        if (!silicon_state_1D[__silicon_1D__1D[i0][i1]])
                        {
                            //
                            for (int i2 = 0; i2 < __silicon_1D__1D__1D[i0][i1].Count; i2 += 1)
                            {
                                sum += 1;
                            }
                            //

                        }
                    }

                    if (sum > 0) { silicon_state_1D[i0] = true; }
                    else         { silicon_state_1D[i0] = false; }


                }

                //


                //
                for (int i1 = 0; i1 < silicon__metal_1D__1D[i0].Count; i1 += 1)
                {
                    if(metal_state_1D[silicon__metal_1D__1D[i0][i1]])
                    { 
                        silicon_state_1D[i0] = true;
                        break;
                    }
                }
                //
            }










        }
        //

    }


    #endregion













    public static class REGION_TOOL
    {

        public static List<int[,]> metal_silicon_layer(int[,][] _info_BOARD_2D)
        {
            /*    
                               -1           0                     1  
            0 ... silicon...  empty   or  P-silicon         or   N-silicon
            1 ... metal  ...  empty   or  metal             or  
            2 ... via    ...  empty   or  meta-silicon-via  or  

            */


            int x_L = _info_BOARD_2D.GetLength(0),
                y_L = _info_BOARD_2D.GetLength(1);

            #region _BOARD_2D_silicon
            int[,] _BOARD_2D_silicon = new int[x_L, y_L];

            for (int y = 0; y < y_L; y += 1)
            {
                for (int x = 0; x < x_L; x += 1)
                {
                    _BOARD_2D_silicon[x,y] = _info_BOARD_2D[x, y][0];



                    //
                }
            }
            // 
            #endregion



            #region _BOARD_2D_metal
            int[,] _BOARD_2D_metal = new int[x_L, y_L];

            for (int y = 0; y < y_L; y += 1)
            {
                for (int x = 0; x < x_L; x += 1)
                {
                    _BOARD_2D_metal[x, y] = _info_BOARD_2D[x, y][1];



                    //
                }
            }
            // 
            #endregion


            return new List<int[,]>()
            {
                _BOARD_2D_silicon,
                _BOARD_2D_metal
            };

        }


        public static int _region_containing_pos(int[] _pos , List<List<int[]>> region_1D)
        {
            for(int i0 = 0; i0 < region_1D.Count; i0 += 1)
            {
                for(int i1 = 0; i1 < region_1D[i0].Count; i1 += 1)
                {
                    if(region_1D[i0][i1][0] == _pos[0] && region_1D[i0][i1][1] == _pos[1])
                    {
                        return i0;
                    }
                    //
                }
            }

            return -100;
        }




        public static List<List<int[]>> _Flood_Fill(int[,] BOARD_2D)
        {
            int x_L = BOARD_2D.GetLength(0),
                y_L = BOARD_2D.GetLength(1);

            bool[,] BOARD_2D_evaluate = new bool[x_L, y_L];



            #region INITIALIZE BOARD_2D_wvaluate
            //
            for (int y = 0; y < y_L; y += 1)
            {
                for (int x = 0; x < x_L; x += 1)
                {

                    if(BOARD_2D[x , y] == -1) { BOARD_2D_evaluate[x, y] = true; }
                    else                      { BOARD_2D_evaluate[x, y] = false; }
                }
            }
            // 
            #endregion



            List<List<int[]>> _REGION_1D = new List<List<int[]>>();


            #region evaluate_entire_board
            while (true)
            {

                for (int y = 0; y < y_L; y += 1)
                {
                    for (int x = 0; x < x_L; x += 1)
                    {
                        //
                        if (BOARD_2D_evaluate[x, y]) { continue; }




                        List<int[]> _region = new List<int[]>();

                        _region.Add(new int[2] { x, y });
                        BOARD_2D_evaluate[x, y] = true;


                        int _state = BOARD_2D[x, y];



                        while (true)
                        {

                            #region INITIALIZE_neighbours
                            int[][] _neighbour = new int[4][]
                            {
                                new int[2] { +1 , +0 },
                                new int[2] { +0 , +1 },
                                new int[2] { -1 , +0 },
                                new int[2] { +0 , -1 },
                            };
                            #endregion


                            bool found_one_need_to_be_evaluated = false;

                            #region neighbour_split
                            for (int i0 = 0; i0 < _region.Count; i0 += 1)
                            {
                                for (int i1 = 0; i1 < _neighbour.Length; i1 += 1)
                                {

                                    int X = _region[i0][0] + _neighbour[i1][0],
                                        Y = _region[i0][1] + _neighbour[i1][1];

                                    if (X >= 0 && X < x_L && Y >= 0 && Y < y_L)
                                    {
                                        if (!BOARD_2D_evaluate[X, Y])
                                        {
                                            if (BOARD_2D[X, Y] == _state)
                                            {
                                                _region.Add(new int[2] { X, Y });

                                                found_one_need_to_be_evaluated = true;
                                                BOARD_2D_evaluate[X, Y] = true;
                                            }
                                            //
                                        }

                                    }






                                }
                                //
                            }
                            #endregion


                            if (!found_one_need_to_be_evaluated) { break; }

                        }
                        //



                        _REGION_1D.Add(_region);

                        //

                    }
                }






                //


                //
                #region _entire_board_evaluated....break
                bool _entire_BOARD_evaluated = true;
                for (int y = 0; y < y_L; y += 1)
                {
                    for (int x = 0; x < x_L; x += 1)
                    {
                        if (!BOARD_2D_evaluate[x, y])
                        {
                            _entire_BOARD_evaluated = false;
                            break;
                        }
                        //
                    }
                }

                if (_entire_BOARD_evaluated) { break; }
                #endregion







            }
            #endregion


            return _REGION_1D;
            //
        }



    }

















    #region _INPUT_
    public static class _INPUT_
    {
        public static void paint_info_BOARD_2D(Vector2 pos2D, int[,][] _info_BOARD_2D)
        {
            if (Input.GetMouseButton(0))
            {
                int X = Mathf.RoundToInt(pos2D.x),
                    Y = Mathf.RoundToInt(pos2D.y);


                if (X >= 0 && X < _info_BOARD_2D.GetLength(0) && Y >= 0 && Y < _info_BOARD_2D.GetLength(1))
                {



                    if      (Input.GetKey(KeyCode.Alpha0)) { _info_BOARD_2D[X, Y][0] = 0; }
                    else if (Input.GetKey(KeyCode.Alpha1)) { _info_BOARD_2D[X, Y][0] = 1; }
                    else if (Input.GetKey(KeyCode.Alpha2)) { _info_BOARD_2D[X, Y][1] = 0; }
                    else if (Input.GetKey(KeyCode.Alpha3))
                    { if (_info_BOARD_2D[X, Y][0] != -1 && _info_BOARD_2D[X, Y][1] != -1) { _info_BOARD_2D[X, Y][2] = 0; } }


                }
                //
            }
        }


        //

    }

    #endregion



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
            //
        }

    }
    #endregion





    #region DRAW
    public static class DRAW
    {
        public static float dt = 1f;
        public static Color col = Color.red;


        public static void QUAD(Vector3 o, float s_0, float s_0_t = 0.95f, float s_1_t = 0.88f)
        {
            float r = Mathf.Sqrt(s_0 * s_0 + s_0 * s_0) / 2f;

            for (int i = 0; i < 4; i += 1)
            {
                Vector3 a = new Vector3()
                {
                    x = Mathf.Cos(Mathf.PI / 4 + Mathf.PI / 2 * i),
                    y = Mathf.Sin(Mathf.PI / 4 + Mathf.PI / 2 * i),
                } * r;

                Vector3 b = new Vector3()
                {
                    x = Mathf.Cos(Mathf.PI / 4 + Mathf.PI / 2 * (i + 1)),
                    y = Mathf.Sin(Mathf.PI / 4 + Mathf.PI / 2 * (i + 1)),
                } * r;


                Debug.DrawLine(o + a * s_0_t, o + b * s_0_t, col, dt);
                Debug.DrawLine(o + a * s_1_t, o + b * s_1_t, col, dt);

            }

        }

        //

        public static void LINE(Vector3 a, Vector3 b, float e = 0f)
        {
            Vector3 n = b - a;
            n = new Vector3(-n.y, n.x).normalized;


            Debug.DrawLine(a + n * e, b + n * e, col, dt);
            Debug.DrawLine(a - n * e, b - n * e, col, dt);

        }

        //









        #region ad
        


        public static void ad_info_BOARD(int[,][] _info_BOARD_2D)
        {
            for (int y = 0; y < _info_BOARD_2D.GetLength(1); y += 1)
            {
                for (int x = 0; x < _info_BOARD_2D.GetLength(0); x += 1)
                {
                    //

                    if (_info_BOARD_2D[x, y][0] == -1)      { DRAW.col = Color.HSVToRGB(0.00f, 0.0f, 0.4f); }
                    else if (_info_BOARD_2D[x, y][0] == +0) { DRAW.col = Color.HSVToRGB(0.00f, 0.5f, 0.9f); }
                    else if (_info_BOARD_2D[x, y][0] == +1) { DRAW.col = Color.HSVToRGB(0.15f, 0.5f, 0.9f); }

                    DRAW.QUAD(new Vector3(x, y, 0f), 1f);




                    if (_info_BOARD_2D[x, y][1] == 0)
                    {
                        DRAW.col = Color.HSVToRGB(0.6f, 0.5f, 0.9f);
                        DRAW.QUAD(new Vector3(x, y, 0f), 0.5f);
                    }
                    if (_info_BOARD_2D[x, y][2] == 0)
                    {
                        DRAW.col = Color.HSVToRGB(0.75f, 0.5f, 0.9f);
                        DRAW.QUAD(new Vector3(x, y, 0f), 0.3f);
                    }
                    //

                }
            }
        } 
        #endregion

    }
    #endregion





}
