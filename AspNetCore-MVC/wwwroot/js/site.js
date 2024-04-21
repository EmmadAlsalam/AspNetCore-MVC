document.addEventListener('DOMContentLoaded', function () {
    handleProfileImageUpload()
})
function handleProfileImageUpload() {
    try {
        let fileUploader = document.querySelector('#fileUploader')
        if (fileUploader != undefined) {
            fileUploader.addEventListener('change', function () {
                if (this.files.length > 0) {
                    this.form.submit()
                }
            })
        }
    }
    catch { }
}


document.addEventListener('DOMContentLoaded', function () {

    let sw = document.querySelector('#switch-mode')
    sw.addEventListener('change', function () {
        let theme = this.checked ? "dark" : "light"


        fetch(`/sitesettings/changetheme?theme=${theme}`)
            .then(res => {
                if (res.ok)
                    window.location.reload()
                else
                console.log("Något är fel")
            })
    })

})