var btnAddImage = document.getElementById("BtnAddImage");
var images = document.getElementById("Images");
var counterImage = 0;

function AddImages() {
  counterImage++;
  var input = document.createElement("input");
  input.type = "text";
    input.setAttribute("asp-for", "Images");
    images.innerHTML += `<div>
        <input asp-for="Images[${counterImage}]" class="form-control mt-2" style="float: right; width: 90%; text-align: right;" placeholder="ادخل رابط الصورة   " />
        <button id="imagebtn${counterImage}"  onclick="return this.parentNode.remove();" class="btn btn-danger" style="width: 8%; float: left; margin-top: 10px;" > - </button>
        <span asp-validation-for="Images[${counterImage}]" class="text-danger"></span>
        </div>`;
}


// function DeleteImageInput(){
//     var parent =
// }

var btnAddVideos = document.getElementById("BtnAddVideo");
var videos = document.getElementById("Videos");
var counterVideo = 0;

function AddVideo() {
  counterVideo++;
  videos.innerHTML += `<div>
        <input asp-for="Videos[${counterVideo}]" class="form-control mt-2" style="float: right; width: 90%; text-align: right;" placeholder="ادخل رابط الفيديو  "  />
        <button id="imagebtn${counterImage}"  onclick="return this.parentNode.remove();" class="btn btn-danger" style="width: 8%; float: left; margin-top: 10px;" > - </button>
        <span asp-validation-for="Videos[${counterVideo}]" class="text-danger"></span>
        </div>`;
}

var btnAddPdf = document.getElementById("BtnAddPDF");
var PDFs = document.getElementById("PDFs");
var counterPdf = 0;

function AddPDF() {
  counterPdf++;
  PDFs.innerHTML += `<div>
        <input asp-for="Pdfs[${counterPdf}]" class="form-control mt-2" style="float: right; width: 90%; text-align: right;"  placeholder="ادخل رابط الملف  " />
        <button id="imagebtn${counterImage}"  onclick="return this.parentNode.remove();" class="btn btn-danger" style="width: 8%; float: left; margin-top: 10px;" > - </button>
        <span asp-validation-for="Pdfs[${counterPdf}]" class="text-danger"></span>
        </div>`;
}

///////////////// Hide And Display Images //////////////////
var ImageContainer = document.getElementById("ContainerImages");

function visibaleAndHideImages() {
  if (ImageContainer.style.display != "none") {
    ImageContainer.style.display = "none";
  } else {
    ImageContainer.style.display = "block";
  }
}

///////////////// Hide And Display Images //////////////////
var VideoContainer = document.getElementById("ContainerVideos");

function visibaleAndHideVideos() {
  if (VideoContainer.style.display != "none") {
    VideoContainer.style.display = "none";
  } else {
    VideoContainer.style.display = "block";
  }
}

///////////////// Hide And Display Images //////////////////
var PDFContainer = document.getElementById("ContainerPDFs");

function visibaleAndHidePDF() {
  if (PDFContainer.style.display != "none") {
    PDFContainer.style.display = "none";
  } else {
    PDFContainer.style.display = "block";
  }
}
