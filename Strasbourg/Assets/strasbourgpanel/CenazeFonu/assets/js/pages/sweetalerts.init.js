! function (t) {
  "use strict";
  var e = function () { };
  e.prototype.init = function () {
    t("#sa-basic").on("click", function () {
      Swal.fire({
        title: "Any fool can use a computer!",
        confirmButtonColor: "#348cd4"
      })
    }), t("#sa-title").click(function () {
      Swal.fire({
        title: "The Internet?",
        text: "That thing is still around?",
        type: "question",
        confirmButtonColor: "#348cd4"
      })
    }), t("#sa-success").click(function () {
      Swal.fire({
        title: "İşlem Başarılı!",
        type: "success",
        confirmButtonColor: "#348cd4"
      }), $('#householder').modal('toggle'),
        $('#sendsms').modal('toggle')
    }),

      t(".sa-success").click(function () {
        Swal.fire({
          title: "İşlem Başarılı!",
          type: "success",
          confirmButtonColor: "#348cd4"
        }), $('#delete').modal('toggle'),
          $('#addemailtemplate').modal('toggle')

      }),

      t(".sa-success-sms").click(function () {
        var mn = document.getElementById("membernumber");
        var membernumber = mn.value;
        if (membernumber == "") {
          $("#errormembernumber").css("display", "block");
        }
        else {
          Swal.fire({
            title: "İşlem Başarılı!",
            type: "success",
            confirmButtonColor: "#348cd4",
          }),
            $('#sendsms').modal('toggle'),
            $("#errormembernumber").css("display", "none"),

            $("#membernumber").val("")
          $("#smstype").val('Ödeme Alındı');


        }
        $('#sendsms').modal('show')
      }),


      t(".sa-success-mpsettings").click(function () {
 
          Swal.fire({
            title: "İşlem Başarılı!",
            type: "success",
            confirmButtonColor: "#348cd4",
          }),
            $('#mpadd').modal('toggle')
           
      }),
      t(".sa-success-company").click(function () {
   
          Swal.fire({
            title: "İşlem Başarılı!",
            type: "success",
            confirmButtonColor: "#348cd4",
          }),
            $('#company').modal('toggle')
           
      }),

      t(".sa-success-email").click(function () {
        var mn = document.getElementById("membernumberemail");
        var membernumber = mn.value;
        if (membernumber == "") {
          $("#errormembernumberemail").css("display", "block");
        }
        else {
          Swal.fire({
            title: "İşlem Başarılı!",
            type: "success",
            confirmButtonColor: "#348cd4",
          }),
            $('#sendemail').modal('toggle'),
            $("#errormembernumberemail").css("display", "none"),

            window.location.reload();

        }
        $('#sendemail').modal('show')
      }),





      t(".sa-success-newmemberform").click(function () {

        {
          var adsoyad = document.getElementById("adsoyad").value.trim();
          var email = document.getElementById("email").value.trim();
          var tel = document.getElementById("tel").value.trim();
          var dtarihi = document.getElementById("datepicker2").value.trim();
          var fransadresi = document.getElementById("fransadresi").value.trim();
          var turkiyeadresi = document.getElementById("turkiyeadresi").value.trim();
          var fransapostakodu = document.getElementById("fransapostakodu").value.trim();
          var turkiyepostakodu = document.getElementById("turkiyepostakodu").value.trim();


          if (adsoyad != "" && email != "" && tel != "" && dtarihi != "" && fransadresi != "" && turkiyeadresi != "" && fransapostakodu != "" && turkiyeadresi != "" && turkiyepostakodu != "") {
            Swal.fire({
              title: "Kayıt Başarılı!",
              type: "success",
              confirmButtonColor: "#348cd4",
            }),
              $('#newmemberform').modal('toggle')
          }
        }
      }),

      t(".newmemberformopen").click(function () {

        {
          document.getElementById("adsoyad").value = "";
          document.getElementById("email").value = "";
          document.getElementById("tel").value = "";
          document.getElementById("datepicker2").value = "";
          document.getElementById("fransadresi").value = "";
          document.getElementById("turkiyeadresi").value = "";
          document.getElementById("fransapostakodu").value = "";
          document.getElementById("turkiyepostakodu").value = "";
        }
      }),


      t(".sa-success-emailsubject").click(function () {
        var es = document.getElementById("emailsubject");
        var emailsubject = es.value;
        var emailcontent = $('#emailcontent').summernote('code').trim();

        if (emailsubject != "" && emailcontent != "") {
          Swal.fire({
            title: "İşlem Başarılı!",
            type: "success",
            confirmButtonColor: "#348cd4",
          }),
            $('#addemailtemplate').modal('toggle'),
            $("#erroremailsubject").css("display", "none"),
            $("#erroremailcontent").css("display", "none"),

            $("#emailsubject").val(""),
            $('#emailcontent').summernote('code', '');

        }
        else if (emailsubject == "" && (emailcontent == "" || emailcontent == null || emailcontent == " ")) {
          $("#erroremailsubject").css("display", "block"),
            $("#erroremailcontent").css("display", "block"),
            $('#addemailtemplate').modal('show')

        }
        else if (emailsubject != "" && emailcontent == "") {
          $("#erroremailcontent").css("display", "block");
          $("#erroremailsubject").css("display", "none"),
            $('#addemailtemplate').modal('show')
        }
        else if (emailsubject == "" && emailcontent != "") {
          $("#erroremailsubject").css("display", "block");
          $("#erroremailcontent").css("display", "none"),
            $('#addemailtemplate').modal('show')
        }
      }),
      t(".sa-success-emaildetailsubject").click(function () {
        var es = document.getElementById("emailsubject");
        var emailsubject = es.value;
        var emailcontent = $('#emailcontent').summernote('code').trim();

        if (emailsubject != "" && emailcontent != "") {
          Swal.fire({
            title: "İşlem Başarılı!",
            type: "success",
            confirmButtonColor: "#348cd4",
          }),
            $('#addemailtemplate').modal('toggle'),
            $("#erroremailsubject").css("display", "none"),
            $("#erroremailcontent").css("display", "none")

        }
        else if (emailsubject == "" && (emailcontent == "" || emailcontent == null || emailcontent == " ")) {
          $("#erroremailsubject").css("display", "block"),
            $("#erroremailcontent").css("display", "block"),
            $('#addemailtemplate').modal('show')

        }
        else if (emailsubject != "" && emailcontent == "") {
          $("#erroremailcontent").css("display", "block");
          $("#erroremailsubject").css("display", "none"),
            $('#addemailtemplate').modal('show')
        }
        else if (emailsubject == "" && emailcontent != "") {
          $("#erroremailsubject").css("display", "block");
          $("#erroremailcontent").css("display", "none"),
            $('#addemailtemplate').modal('show')
        }
      })

      , t("#sa-error").click(function () {
        Swal.fire({
          type: "error",
          title: "Oops...",
          text: "Something went wrong!",
          confirmButtonColor: "#348cd4",
          footer: '<a href="">Why do I have this issue?</a>'
        })
      }), t("#sa-long-content").click(function () {
        Swal.fire({
          imageUrl: "https://placeholder.pics/svg/300x1500",
          imageHeight: 1500,
          imageAlt: "A tall image",
          confirmButtonColor: "#348cd4"
        })
      }), t("#sa-custom-position").click(function () {
        Swal.fire({
          position: "top-end",
          type: "success",
          title: "Your work has been saved",
          showConfirmButton: !1,
          timer: 1500
        })
      }), t("#sa-warning").click(function () {
        Swal.fire({
          title: "Are you sure?",
          text: "You won't be able to revert this!",
          type: "warning",
          showCancelButton: !0,
          confirmButtonColor: "#348cd4",
          cancelButtonColor: "#6c757d",
          confirmButtonText: "Yes, delete it!"
        }).then(function (t) {
          t.value && Swal.fire("Deleted!", "Your file has been deleted.", "success")
        })
      }), t(".sa-params").click(function () {
        Swal.fire({
          title: "Emin misiniz?",
          text: "Bu işlemi geri alamayacaksınız!",
          type: "warning",
          showCancelButton: !0,
          confirmButtonText: "Evet, sil!",
          cancelButtonText: "Hayır, Iptal Et!",
          confirmButtonClass: "btn btn-success mt-2",
          cancelButtonClass: "btn btn-danger ml-2 mt-2",
          buttonsStyling: !1
        }).then(function (t) {
          t.value ? Swal.fire({
            title: "Silindi!",
            type: "success"
          }) : t.dismiss === Swal.DismissReason.cancel && Swal.fire({
            title: "Iptal Edildi!",
            type: "error"
          })
        })
      }), t(".sa-params-deniedrequest").click(function () {
        Swal.fire({
          title: "Emin misiniz?",
          text: "Bu işlemi geri alamayacaksınız!",
          type: "warning",
          showCancelButton: !0,
          confirmButtonText: "Evet, sil!",
          cancelButtonText: "Hayır, Iptal Et!",
          confirmButtonClass: "btn btn-success mt-2",
          cancelButtonClass: "btn btn-danger ml-2 mt-2",
          buttonsStyling: !1
        }).then(function (t) {
          t.value ? Swal.fire({
            title: "Talep Reddedildi!",
            type: "success",
            
          }) : t.dismiss === Swal.DismissReason.cancel && Swal.fire({
            title: "İşlem İptal Edildi!",
            type: "error"
          })
        })
      }), t(".sa-params-successrequest").click(function () {
        Swal.fire({
          title: "Emin misiniz?",
          text: "Bu işlemi geri alamayacaksınız!",
          type: "warning",
          showCancelButton: !0,
          confirmButtonText: "Evet, sil!",
          cancelButtonText: "Hayır, Iptal Et!",
          confirmButtonClass: "btn btn-success mt-2",
          cancelButtonClass: "btn btn-danger ml-2 mt-2",
          buttonsStyling: !1
        }).then(function (t) {
          t.value ? Swal.fire({
            title: "Talep Onaylandı!",
            type: "success"
          }) : t.dismiss === Swal.DismissReason.cancel && Swal.fire({
            title: "İşlem İptal Edildi!",
            type: "error"
          })
        })
      }), t(".sa-params2").click(function () {
        Swal.fire({
          title: "Emin misiniz?",
          text: "Bu işlemi geri alamayacaksınız!",
          type: "warning",
          showCancelButton: !0,
          confirmButtonText: "Evet, sil!",
          cancelButtonText: "Hayır, Iptal Et!",
          confirmButtonClass: "btn btn-success mt-2",
          cancelButtonClass: "btn btn-danger ml-2 mt-2",
          buttonsStyling: !1
        }).then(function (t) {
          t.value ? Swal.fire({
            title: "Silindi!",
            type: "success"
          }) : t.dismiss === Swal.DismissReason.cancel && Swal.fire({
            title: "Iptal Edildi!",
            type: "error"
          })
        })
      }), t(".sa-transfer").click(function () {
        Swal.fire({
          title: "Transferi Onaylıyor musunuz?",
          text: "Bu işlemi geri alamayacaksınız!",
          type: "warning",
          showCancelButton: !0,
          confirmButtonText: "Evet, Onaylıyorum!",
          cancelButtonText: "Hayır, Iptal Et!",
          confirmButtonClass: "btn btn-success mt-2",
          cancelButtonClass: "btn btn-danger ml-2 mt-2",
          buttonsStyling: !1
        }).then(function (t) {
          t.value ? Swal.fire({
            title: "Transfer İşlemi Başarılı !",
            type: "success"
          }, $('#custom-width-modal').modal().modal('toggle')) : t.dismiss === Swal.DismissReason.cancel && Swal.fire({
            title: "Iptal Edildi!",
            type: "error"
          })
        })
      }), t(".sa-dead").click(function () {
        Swal.fire({
          title: "Aşağıdaki kişiyi VEFAT EDEN Kişi Kayıtlarına almak istediğinize eminmisiniz? Bu işlem geri alınamaz !",
          text: "Cafer Cindoruk",
          type: "warning",
          showCancelButton: !0,
          confirmButtonText: "Evet, Onaylıyorum!",
          cancelButtonText: "Hayır, Iptal Et!",
          confirmButtonClass: "btn btn-success mt-2",
          cancelButtonClass: "btn btn-danger ml-2 mt-2",
          buttonsStyling: !1
        }).then(function (t) {
          t.value ? Swal.fire({
            title: "İşlem Başarılı !",
            type: "success",

          }, $('#dead').modal('toggle')) : t.dismiss === Swal.DismissReason.cancel && Swal.fire({
            title: "Iptal Edildi!",
            type: "error"
          })
        })
      }), t(".sa-adresschange").click(function () {
        Swal.fire({
          title: "Adres Değişikliğini Onaylıyor musunuz?",
          text: "Bu işlemi geri alamayacaksınız!",
          type: "warning",
          showCancelButton: !0,
          confirmButtonText: "Evet, Onaylıyorum!",
          cancelButtonText: "Hayır, Iptal Et!",
          confirmButtonClass: "btn btn-success mt-2",
          cancelButtonClass: "btn btn-danger ml-2 mt-2",
          buttonsStyling: !1
        }).then(function (t) {
          t.value ? Swal.fire({
            title: "Adres Değişikliği İşlemi Başarılı !",
            type: "success"
          }) : t.dismiss === Swal.DismissReason.cancel && Swal.fire({
            title: "Iptal Edildi!",
            type: "error"
          })
        })
      }), t("#sa-image").click(function () {
        Swal.fire({
          title: "Zircos",
          text: "Responsive Bootstrap 4 Admin Dashboard",
          imageUrl: "assets/images/logo-sm.png",
          imageHeight: 50,
          animation: !1,
          confirmButtonColor: "#348cd4"
        })
      }), t("#sa-close").click(function () {
        var t;
        Swal.fire({
          title: "Auto close alert!",
          html: "I will close in <strong></strong> seconds.",
          timer: 2e3,
          onBeforeOpen: function () {
            Swal.showLoading(), t = setInterval(function () {
              Swal.getContent().querySelector("strong").textContent = Swal.getTimerLeft()
            }, 100)
          },
          onClose: function () {
            clearInterval(t)
          }
        }).then(function (t) {
          t.dismiss === Swal.DismissReason.timer && console.log("I was closed by the timer")
        })
      }), t("#custom-html-alert").click(function () {
        Swal.fire({
          title: "<i>HTML</i> <u>example</u>",
          type: "info",
          html: 'You can use <b>bold text</b>, <a href="//coderthemes.com/">links</a> and other HTML tags',
          showCloseButton: !0,
          showCancelButton: !0,
          confirmButtonColor: "#348cd4",
          cancelButtonColor: "#f1556c",
          confirmButtonText: '<i class="mdi mdi-thumb-up-outline"></i> Great!',
          cancelButtonText: '<i class="mdi mdi-thumb-down-outline"></i>'
        })
      }), t("#custom-padding-width-alert").click(function () {
        Swal.fire({
          title: "Custom width, padding, background.",
          width: 600,
          padding: 100,
          confirmButtonColor: "#348cd4",
          background: "#fff url(//subtlepatterns2015.subtlepatterns.netdna-cdn.com/patterns/geometry.png)"
        })
      }), t("#ajax-alert").click(function () {
        Swal.fire({
          title: "Submit your Github username",
          input: "text",
          inputAttributes: {
            autocapitalize: "off"
          },
          showCancelButton: !0,
          confirmButtonText: "Look up",
          confirmButtonColor: "#348cd4",
          cancelButtonColor: "#6c757d",
          showLoaderOnConfirm: !0,
          preConfirm: function (t) {
            return fetch("//api.github.com/users/" + t).then(function (t) {
              if (!t.ok) throw new Error(t.statusText);
              return t.json()
            }).catch(function (t) {
              Swal.showValidationMessage("Request failed: " + t)
            })
          },
          allowOutsideClick: function () {
            Swal.isLoading()
          }
        }).then(function (t) {
          t.value && Swal.fire({
            title: t.value.login + "'s avatar",
            imageUrl: t.value.avatar_url
          })
        })
      }), t("#chaining-alert").click(function () {
        Swal.mixin({
          input: "text",
          confirmButtonText: "Next &rarr;",
          showCancelButton: !0,
          confirmButtonColor: "#348cd4",
          cancelButtonColor: "#6c757d",
          progressSteps: ["1", "2", "3"]
        }).queue([{
          title: "Question 1",
          text: "Chaining swal2 modals is easy"
        }, "Question 2", "Question 3"]).then(function (t) {
          t.value && Swal.fire({
            title: "All done!",
            html: "Your answers: <pre><code>" + JSON.stringify(t.value) + "</code></pre>",
            confirmButtonText: "Lovely!"
          })
        })
      }), t("#dynamic-alert").click(function () {
        swal.queue([{
          title: "Your public IP",
          confirmButtonText: "Show my public IP",
          confirmButtonColor: "#348cd4",
          text: "Your public IP will be received via AJAX request",
          showLoaderOnConfirm: !0,
          preConfirm: function () {
            return new Promise(function (e) {
              t.get("https://api.ipify.org?format=json").done(function (t) {
                swal.insertQueueStep(t.ip), e()
              })
            })
          }
        }])
      })
  }, t.SweetAlert = new e, t.SweetAlert.Constructor = e
}(window.jQuery),
  function (t) {
    "use strict";
    window.jQuery.SweetAlert.init()
  }();