function likeEvent(eventId) {
  $.ajax({
    url: "/Home/LikeEvent",
    type: "POST",
    data: { eventId: eventId },
    success: function (result) {
      if (result.success) {
        $("#like-count-" + eventId).text(result.likesCount);
      }
    },
    error: function () {
      alert("Failed to like the event.");
    },
  });
}


document.querySelectorAll(".rsvp-form").forEach(form => {
    form.addEventListener("submit", function (event) {
        event.preventDefault(); // Prevent the form from redirecting

        const formData = new FormData(this); // Serialize the form data
        const url = this.action; // Get the form's action URL
        const rsvpButton = this.querySelector("button"); // The RSVP button inside the form

        // Fetch API to send the form data asynchronously
        fetch(url, {
            method: "POST",
            headers: {
                'X-Requested-With': 'XMLHttpRequest', // Identify the request as an AJAX request
                'X-CSRF-Token': document.querySelector('input[name="__RequestVerificationToken"]').value // CSRF token
            },
            body: new URLSearchParams(formData)
        })
        .then(response => response.json()) // Parse the JSON response
        .then(result => {
            if (result.success) {
                // Change the RSVP button's appearance and text based on the response
                rsvpButton.classList.remove("btn-primary", "btn-success");
                rsvpButton.classList.add(result.isRsvped ? "btn-success" : "btn-primary");
                rsvpButton.textContent = result.isRsvped ? "Attending" : "RSVP";
            } else {
                alert("RSVP failed. Please try again.");
            }
        })
        .catch(error => console.error('Error:', error)); // Handle any errors
    });
});
