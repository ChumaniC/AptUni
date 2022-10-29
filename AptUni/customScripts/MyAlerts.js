function submit_answer() {
    Swal.fire({
        title: 'Submit Answers?',
        text: "Submitting answer will save all selected options. Are you sure you want to submit answers?",
        icon: 'caution',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, submit!'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                'Answers Submitted',
                'Your answers have been successfully submitted.',
                'success'
            ).then(function () {
                window.location = "../presentationLayer/TestSelection.aspx";
                window.sessionStorage.removeItem("count_timer");
            });
        }
    })
};

function end_test() {
    Swal.fire({
        title: 'End Test?',
        text: "Ending the test will not save selected options. Are you sure you want to end the test?",
        icon: 'caution',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, end!'
    }).then((result) => {
        if (result.isConfirmed) {
            window.location = "../presentationLayer/TestSelection.aspx";
            window.sessionStorage.removeItem("count_timer");
        }
    })  
};

function info_submitted() {
    Swal.fire({
        icon: 'success',
        title: 'Registration Complete.',
        text: 'Your information has been submitted successfully.'
    }).then(function () {
        window.location = "../presentationLayer/LandingPage.aspx";
    });
}

function dashboard() {
    Swal.fire({
        icon: 'caution',
        title: 'Dashboard Unavailable.',
        text: 'You must write at least one test to view the dashboard.'
    }).then(function () {
        window.location = "../presentationLayer/LandingPage.aspx";
    });
}

function Subject_Length() {
    Swal.fire({
        icon: 'caution',
        title: 'Subject mark error',
        text: 'The supplied mark does not meet the minimum length requirement of 1 character or exceeds the allowed limit of 25 characters. Try again.'
    })
}

function Surname_Length() {
    Swal.fire({
        icon: 'caution',
        title: 'Surname error',
        text: 'The supplied surname does not meet the minimum length requirement of 1 character or exceeds the allowed limit of 25 characters. Try again.'
    })
}

function Name_Length() {
    Swal.fire({
        icon: 'caution',
        title: 'Name error',
        text: 'The supplied name does not meet the minimum length requirement of 1 character or exceeds the allowed limit of 25 characters. Try again.'
    })
}


function Email_Length() {
    Swal.fire({
        icon: 'caution',
        title: 'Email address limit error',
        text: 'The supplied email address does not meet the minimum length requirement of 1 character or exceeds the allowed limit of 25 characters. Try again.'
    })
}

function Password_Length() {
    Swal.fire({
        icon: 'caution',
        title: 'Password error',
        text: 'The supplied password does not meet the minimum length requirement of 1 character or exceeds the allowed limit of 25 characters. Try again.'
    })
}

