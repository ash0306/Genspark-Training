var nameInput = document.getElementById("name");
var descriptionInput = document.getElementById("description");
var categoryInput = document.getElementById("category");
var statusInput = document.getElementById("status");
var priceInput = document.getElementById("price");
var stockInput = document.getElementById("stock");
var imageInput = document.getElementById("image");

var token = sessionStorage.getItem("employeeToken");

document.addEventListener("DOMContentLoaded", function () {
  statusInput.addEventListener("change", function () {
    if (statusInput.value === "Available") {
      stockInput.disabled = false;
    } else {
      stockInput.disabled = true;
      stockInput.value = 0;
    }
  });
});

function newProduct() {
  const form = document.getElementById("newProductForm");

  form.addEventListener("submit", async function (event) {
    event.preventDefault();

    if (!form.checkValidity()) {
        event.stopPropagation();
        return;
    }

    if (categoryInput.value == "") {
      categorySelect.classList.add("is-invalid");
      categorySelect.classList.remove("is-valid");
      event.stopPropagation();
    }
    if (statusInput.value == "") {
      statusSelect.classList.add("is-invalid");
      statusSelect.classList.remove("is-valid");
      event.stopPropagation();
    }

    fetch("http://localhost:5228/api/product/addProduct", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      body: JSON.stringify({
        name: nameInput.value,
        description: descriptionInput.value,
        category: categoryInput.value,
        status: statusInput.value,
        price: parseInt(priceInput.value),
        stock: parseInt(stockInput.value),
        image: imageUploaded,
      }),
    }).then(async (response) => {
      var data = await response.json();

      if (response.status === 200) {
        newToast(
          "bg-success",
          "Product created successfully!! Redirecting...."
        );
        setTimeout(() => {
          window.location.href = "./Products.html";
        }, 2000);
      } else {
        newToast("bg-danger", "Product creation failed. " + data.message);
      }
    });
  });
}

function newToast(classBackground, message) {
  const toastNotification = new bootstrap.Toast(
    document.getElementById("toastNotification")
  );
  var toast = document.getElementById("toastNotification");
  toast.className = "toast align-items-center text-white border-0";
  toast.classList.add(`${classBackground}`);
  var toastBody = document.querySelector(".toast-body");
  if (toastBody) {
    toastBody.innerHTML = `${message}`;
  }
  toastNotification.show();
}

var imageUploaded = "";
const myWidget = cloudinary.createUploadWidget(
  {
    cloudName: "Bean-Brew",
    uploadPreset: "gymtih7r",
    cropping: true, //add a cropping step
    croppingAspectRatio: 1, // Maintain aspect ratio (e.g., 1 for a square crop)
    showSkipCropButton: false, // Hide the skip cropping button
    sources: ["local", "url"], // restrict the upload sources to URL and local files
    multiple: false, //restrict upload to a single file
    tags: ["users", "product"], //add the given tags to the uploaded files
    clientAllowedFormats: ["jpg", "jpeg", "png", "gif", "avif", "webp"], //restrict uploading to image files only
    maxImageFileSize: 2000000, //restrict file size to less than 2MB
    maxImageWidth: 200, //Scales the image down to a width of 2000 pixels before uploading
  },
  (error, result) => {
    if (!error && result && result.event === "success") {
      document
        .getElementById("uploadedimage")
        .setAttribute("src", result.info.secure_url);
      imageUploaded = result.info.secure_url;
    }
  }
);
document.getElementById("upload_widget").addEventListener(
  "click",
  function (e) {
    e.preventDefault();
    myWidget.open();
  },
  false
);
