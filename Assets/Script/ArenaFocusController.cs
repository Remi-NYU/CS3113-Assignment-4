using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaFocusController : MonoBehaviour
{
    public Animator focused_cam_animator;
    public Animator unfocused_cam_animator;
    public PlayerController focused_player_controller;
    public PlayerController unfocused_player_controller;
    public Canvas timer_canvas;
    public Canvas pause_canvas;

    public float screen_swap_cooldown = 1;

    float swap_timer = 999999;

    void Update()
    {
        swap_timer += Time.deltaTime;

        if (swap_timer >= screen_swap_cooldown && Input.GetKeyDown(KeyCode.Q) && Time.timeScale != 0)
        {
            SwapArena();
        }
    }

    void SwapArena()
    {
        focused_cam_animator.SetTrigger("ScreenSwapShrink");
        unfocused_cam_animator.SetTrigger("ScreenSwapGrow");

        Animator temp_anim = focused_cam_animator;
        focused_cam_animator = unfocused_cam_animator;
        unfocused_cam_animator = temp_anim;

        Camera focused_cam = focused_cam_animator.GetComponent<Camera>();
        pause_canvas.worldCamera = focused_cam;
        timer_canvas.worldCamera = focused_cam;

        focused_player_controller.Deactivate();
        unfocused_player_controller.Activate();

        PlayerController temp_cont = focused_player_controller;
        focused_player_controller = unfocused_player_controller;
        unfocused_player_controller = temp_cont;
    }
}
