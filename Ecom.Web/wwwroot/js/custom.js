function showSuccessAlert() {
    Swal.fire({
        title: 'Success!',
        text: 'Your operation was completed successfully.',
        icon: 'success',
        confirmButtonText: 'OK',
        confirmButtonColor: '#28a745',
        background: '#f0fff4',
        color: '#155724',
        timer: 3000,
        timerProgressBar: true,
    });
}

function showErrorAlert() {
    Swal.fire({
        title: 'Error!',
        text: 'Something went wrong. Please try again.',
        icon: 'error',
        confirmButtonText: 'Retry',
        confirmButtonColor: '#d33',
        background: '#fff5f5',
        color: '#721c24',
    });
}
