/*
SHENZEN IO


sprite
text


// functionality

editor_button
	home back stimulate step
----
texture
tm

start with default texture
inside_region than hover texture
inside_region and held_down than active_texture and 
	loop 
        if(!held_down)
          if(inside_region)
            // do somthng
          break  
----

 

slider
	speed_control 
----
texture
tm


default 

inside_region and held_down
	loop
    	step_index from clamp pos2D.x - o.x
        [step_index] _texture
        // do somthng with step_index
    	if(!held_down)
        	break
        
----
    
    

status
	full_screen stats
----

tm , texture

----
	
tool_tip
	when hover on timeline
----

tm , texture
appear when hover over somthng 
with tm value

----



chip
	switch button dial_timer PGA33X6
----
PGA33X6
	texture
    toggle(default or active)_1D

----


tile
	edge_connector
	outline_boundary 

*/












/*
when held down 
	inside_region
		instant switch to o1(x , y)
*/
tab_button
	o  (x , y)
	n  (x , y)
	o1 (x , y)
	cam.transform





/*
when held down
	inside_region
		loop
			if(not_held_down)
				if(inside_region)
					// using index_to_assign
					// break
				else		
					// break
*/
button_to_assign_key_code
	o  (x , y)
	n  (x , y)
	sr
	sprite _0 , _1
	index_in_assign
	


/*
when held down
	inside_region
		loop
			// step_index using clamped(pos2D)
 			// using index_to_assign
			if(not_held_down)
				// break
*/
slider
	o  (x , y)
	n  (x , y)
	sr
	sprite_1D
	index_in_assign



