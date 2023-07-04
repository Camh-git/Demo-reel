function Assign_submit_actions(){
    //Get the submit btns/forms and assign their actions to the functions
    document.getElementById("DS_form").addEventListener('submit',event =>{
        event.preventDefault();
        Hello_world();
    })
}
function Hello_world(){
    alert("Hello_world");
}

//Manage books
function Call_upload_book(){}
function Call_delete_book(){}
function Call_rename_book(){}

//Manage folders
function Call_upload_folder(){}
function Call_delete_folder(){}
function Call_rename_folder(){}

//Manage library
function Call_create_folder(){}
function Call_MV_folder(){}

//Manage thumbnails
function Call_re_assign_thumb(){}
function Call_clear_or_repop_thumb_cache(){}

//Misc options
function Call_toggle_downloads(){}
function Call_toggle_readers(){}
function Call_manage_ip_lists(){}

Assign_submit_actions();