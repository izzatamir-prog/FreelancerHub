function showUpdateModal(id) {
    fetch(`/api/freelancer/${id}`)
        .then(res => res.json())
        .then(data => {
            document.getElementById("freelancerId").value = data.id;
            document.getElementById("updateUsername").value = data.username;
            document.getElementById("updateEmail").value = data.email;
            document.getElementById("updatePhoneNo").value = data.phoneNo;
            //document.getElementById("updateSkillset").value = data.skillsets.map(s => s.name).join(", ");
            //document.getElementById("updateHobby").value = data.hobbies.map(h => h.name).join(", ");

            $('#updateModal').modal('show');
        })
        .catch(error => {
            console.error("Failed to load freelancer:", error);
        });
}

function submitUpdate() {
    const id = document.getElementById("freelancerId").value;
    const updated = {
        id: parseInt(id),
        username: document.getElementById("updateUsername").value,
        email: document.getElementById("updateEmail").value,
        phoneNo: document.getElementById("updatePhoneNo").value,
        //skillsets: document.getElementById("updateSkillset").value.split(",").map(s => ({name: s.trim() })),
        //hobbies: document.getElementById("updateHobby").value.split(",").map(h => ({ name: h.trim() })),
        isArchive: false,
        skillsets: [],
        hobbies: []
    };



    fetch(`/api/freelancer/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(updated)
    })
        .then(res => {
            if (res.ok) {
                $('#updateModal').modal('hide');
                alert("Freelancer updated!");
                location.reload();
            } else {
                alert("Update failed.");
            }
        })
        .catch(err => console.error("Update error:", err));
}

function archiveFreelancer(id) {
    if (!confirm("Are you sure you want to archive this freelancer?")) return;

    fetch(`/api/freelancer/archive/${id}`, {
        method: "PATCH"
    })
        .then(res => {
            if (res.ok) {
                alert("Freelancer archived.");
                location.reload();
            } else {
                alert("Failed to archive.");
            }
        })
        .catch(error => {
            console.error("Archive failed:", error);
        });
}

function unarchiveFreelancer(id) {
    if (!confirm("Unarchive this freelancer?")) return;

    fetch(`/api/freelancer/unarchive/${id}`, {
        method: "PATCH"
    })
        .then(res => {
            if (res.ok) {
                alert("Freelancer unarchived.");
                location.reload();
            } else {
                alert("Failed to unarchive.");
            }
        })
        .catch(error => {
            console.error("Unarchive failed:", error);
        });
}

function deleteFreelancer(id) {
    if (!confirm("Are you sure you want to permanently delete this freelancer?")) return;

    fetch(`/api/freelancer/${id}`, {
        method: "DELETE"
    })
        .then(res => {
            if (res.ok) {
                alert("Freelancer deleted.");
                location.reload();
            } else {
                alert("Failed to delete.");
            }
        })
        .catch(error => {
            console.error("Delete failed:", error);
        });
}
